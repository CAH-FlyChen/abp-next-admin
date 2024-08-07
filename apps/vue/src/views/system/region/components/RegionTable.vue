<template>
  <div>
    <BasicTable @register="registerTable">
      <template #toolbar>
        <a-button v-auth="['Platform.Menu.Create']" type="primary" @click="handleAddNew">{{
          L('AddNew')
        }}</a-button>
      </template>
      <template #bodyCell="{ column, record }">
        <template v-if="column.key === 'name'">
          <span>{{ record.name}}</span>
        </template>
        <template v-else-if="column.key === 'regionTypeCode'">
          <span v-if="record.regionTypeCode===0">国家</span>
          <span v-if="record.regionTypeCode===1">省</span>
          <span v-if="record.regionTypeCode===2">市</span>
          <span v-if="record.regionTypeCode===3">区</span>
        </template>
        <template v-else-if="column.key === 'action'">
          <TableAction
            :actions="[
              {
                auth: 'Platform.Menu.Create',
                label: L('AddNew'),
                icon: 'ant-design:plus-outlined',
                onClick: handleAddNew.bind(null, record),
              },
              {
                auth: 'Platform.Menu.Update',
                label: L('Edit'),
                icon: 'ant-design:edit-outlined',
                onClick: handleEdit.bind(null, record),
              },
              {
                auth: 'Platform.Menu.Delete',
                color: 'error',
                label: L('Delete'),
                icon: 'ant-design:delete-outlined',
                onClick: handleDelete.bind(null, record),
              },
            ]"
          />
        </template>
      </template>
    </BasicTable>
    <RegionDrawer @register="registerDrawer" @change="handleChange" :framework="useFramework" />
  </div>
</template>

<script lang="ts" setup>
  import { ref } from 'vue';
  import { useMessage } from '/@/hooks/web/useMessage';
  import { useLocalization } from '/@/hooks/abp/useLocalization';
  import { BasicTable, useTable, TableAction } from '/@/components/Table';
  import { useDrawer } from '/@/components/Drawer';
  import { getDataColumns } from './RegionData';
  import { getSearchFormSchemas } from './ModalData';
  import { getAll, getById, deleteByCode } from '/@/api/system/regions';
  import { listToTree } from '/@/utils/helper/treeHelper';
  import RegionDrawer from './RegionDrawer.vue';

  const { createMessage, createConfirm } = useMessage();
  const { L } = useLocalization(['AppPlatform', 'AbpUi', 'System']);

  const useFramework = ref('');
  const [registerTable, { reload }] = useTable({
    rowKey: 'code',
    title: L('DisplayName:Region'),
    columns: getDataColumns(),
    api: getAll,
    beforeFetch: (request) => {
      // 子组件需要此参数,拦截一下
      useFramework.value = request.framework;
      return request;
    },
    afterFetch: (result) => {
      return listToTree(result, {
        id: 'code',
        pid: 'parentCode',
      });
    },
    pagination: false,
    striped: false,
    useSearchForm: true,
    showTableSetting: true,
    bordered: true,
    showIndexColumn: false,
    canResize: false,
    formConfig: getSearchFormSchemas(),
    actionColumn: {
      width: 280,
      title: L('Actions'),
      dataIndex: 'action',
    },
  });

  const [registerDrawer, { openDrawer }] = useDrawer();

  function handleAddNew(record?: Recordable) {
    openDrawer(true, {});
  }

  function handleEdit(record: Recordable) {
    getById(record.code).then((data) => {
      openDrawer(true, data);
    });
  }

  function handleDelete(record: Recordable) {
    createConfirm({
      iconType: 'warning',
      title: L('AreYouSure'),
      content: L('ItemWillBeDeletedMessageWithFormat', [record.name]),
      okCancel: true,
      onOk: () => {
        return deleteByCode(record.code).then(() => {
          createMessage.success(L('SuccessfullyDeleted'));
          reload();
        });
      },
    });
  }

  function handleChange() {
    console.log("on handle change called");
    reload();
  }
</script>
