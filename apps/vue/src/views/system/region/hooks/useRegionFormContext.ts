import type { Ref } from 'vue';
import type { TabFormSchema, TabFormActionType } from '/@/components/Form/src/types/form';

import { unref, computed, watch, createVNode } from 'vue';
import { useLocalization } from '/@/hooks/abp/useLocalization';
import { cloneDeep } from 'lodash-es';
import { getAll as getAllRegion, create, update } from '/@/api/system/regions';
import { listToTree } from '/@/utils/helper/treeHelper';
import { Region, UpdateRegion, CreateRegion } from '/@/api/system/regions/model';

interface UseRegionFormContext {
  regionModel: Ref<Region>;
  formElRef: Ref<Nullable<TabFormActionType>>;
  framework: Ref<string | undefined>,
}

export function useRegionFormContext({ regionModel, formElRef, framework }: UseRegionFormContext) {
  console.log("region module is");
  console.log(regionModel);

  const { L } = useLocalization(['AppPlatform','System']);

  function getBasicFormSchemas(): TabFormSchema[] {
    return [
      {
        tab: L('DisplayName:Basic'),
        field: 'code',
        component: 'Input',
        label: '编码',
        colProps: { span: 24 },
        ifShow: true,
        required:true
      },
      {
        tab: L('DisplayName:Basic'),
        field: 'parentCode',
        label: L('DisplayName:ParentRegion'),
        colProps: { span: 24 },
        component: 'TreeSelect',
        componentProps: {
          fieldNames: {
            label: 'name',
            key: 'code',
            value: 'code',
          },
          getPopupContainer: () => document.body,
        },
      },
      {
        tab: L('DisplayName:Basic'),
        field: 'name',
        component: 'Input',
        label: L('DisplayName:Name'),
        colProps: { span: 24 },
        required: true,
      },
      {
        tab: L('DisplayName:Basic'),
        field: 'regionTypeCode',
        component: 'Select',
        componentProps: {
          options: [
            { value: 0, label: '国家' },
            { value: 1, label: '省' },
            { value: 2, label: '市' },
            { value: 3, label: '区' },
          ],
        },
        label: L('DisplayName:RegionType'),
        colProps: { span: 24 },
        required: true,
      }
    ];
  }

  const getFormSchemas = computed((): TabFormSchema[] => {
    return [...getBasicFormSchemas()];
  });

  const formTitle = computed((): string => {
    const region = unref(regionModel);
    if(!region) return "";
    if (region.code) {
      return L('Menu:EditByName', [region.name] as Recordable);
    }
    return L('Menu:AddNew');
  });

  function removeAllMetaSchemas() {
    const tabKey = L('DisplayName:Meta');
    const formEl = unref(formElRef);
    const schemas = unref(getFormSchemas);
    const metaSchemas= schemas.filter((x) => x.tab === tabKey);
    metaSchemas.forEach((x) => {
      formEl?.removeSchemaByField(x.field);
      const index = schemas.findIndex((s) => s.field === x.field);
      if (index) {
        schemas.splice(index, 1);
      }
    });
  }

  function removeAllParentMenus() {
    const formEl = unref(formElRef);
    formEl?.updateSchema({
      field: 'parentCode',
      componentProps: { treeData: [] },
    });
  }
  // 应该没使用
  async function fetchRegionResource() {
      removeAllMetaSchemas();
      await warpParentRootMenu();
  }
  
  async function warpParentRootMenu() {
    removeAllParentMenus();
    const formEl = unref(formElRef);
    const { items } = await getAllRegion({});
    const treeData = listToTree(items, { id: 'code', pid: 'parentCode' });
    const region = unref(regionModel);
    formEl?.updateSchema({
      field: 'parentCode',
      defaultValue: region.parentCode,
      componentProps: { treeData },
    });
  }

  function handleFormSubmit() {
    const formEl = unref(formElRef);
    return formEl?.validate().then(() => {
      debugger;
      const model = unref(regionModel);
      const input = formEl?.getFieldsValue();
      return model.code
        ? update(model.code, cloneDeep(input) as UpdateRegion)
        : create(cloneDeep(input) as CreateRegion);
    });
  }

  watch(
    () => unref(regionModel),
    (model) => {
      const formEl = unref(formElRef);
      formEl?.resetFields();
      formEl?.setFieldsValue(model);
    },
    { immediate: true },
  );

  return {
    formTitle,
    getFormSchemas,
    handleFormSubmit,
    fetchRegionResource,
  };
}
