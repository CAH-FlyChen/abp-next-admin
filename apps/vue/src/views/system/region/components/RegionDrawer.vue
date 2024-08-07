<template>
  <BasicDrawer
    v-bind="$attrs"
    @register="registerDrawer"
    showFooter
    :title="formTitle"
    width="50%"
    @ok="handleSubmit"
  >
    <TabForm
      ref="formElRef"
      :schemas="getFormSchemas"
      :label-width="120"
      :show-action-button-group="false"
      :base-col-props="{
        span: 24,
      }"
      :action-col-options="{
        span: 24,
      }"
    />
  </BasicDrawer>
</template>

<script lang="ts" setup>
  import { nextTick, ref, unref } from 'vue';
  import { useMessage } from '/@/hooks/web/useMessage';
  import { useLocalization } from '/@/hooks/abp/useLocalization';
  import { TabForm, TabFormActionType } from '/@/components/Form';
  import { BasicDrawer, useDrawerInner } from '/@/components/Drawer';
  import { basicProps } from './props';
  import { Region } from '/@/api/system/regions/model';
  import { useRegionFormContext } from '../hooks/useRegionFormContext';

  const emits = defineEmits(['change', 'register']);
  const props = defineProps(basicProps);

  const { createMessage } = useMessage();
  const { L } = useLocalization(['AppPlatform', 'AbpUi']);
  const region = ref<Region>({} as Region);
  const framework = ref<string | undefined>('');
  const formElRef = ref<Nullable<TabFormActionType>>(null);

  const { formTitle, getFormSchemas, handleFormSubmit, fetchRegionResource } = useRegionFormContext({
    regionModel: region,
    formElRef: formElRef,
    framework: framework,
  });
  
  const [registerDrawer, { setDrawerProps, changeOkLoading, closeDrawer }] = useDrawerInner(
    //回调函数
    (dataVal) => {
      region.value = dataVal;
      framework.value = props.framework;
      nextTick(() => {
        setDrawerProps({ confirmLoading: false });
        
        fetchRegionResource();

        const formEl = unref(formElRef);
        formEl?.changeTab(L('DisplayName:Basic'));
      });
    },
  );

  function handleSubmit() {
    changeOkLoading(true);
    handleFormSubmit()
      ?.then(() => {
        createMessage.success(L('Successful'));
        closeDrawer();
        emits('change');
      })
      .finally(() => {
        changeOkLoading(false);
      });
  }
</script>
