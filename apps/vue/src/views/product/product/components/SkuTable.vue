<template>
  <div>
    <SkuEditorModal @register="registerEditorModal" @ok="okClicked" />
  </div>
  <BasicTable
      @register="registerTable" 
      rowKey="id"
    >
      <template #toolbar>
        <a-button type="primary" @click="handleAddNew"> 添加 </a-button>
      </template>

      <template #bodyCell="{ column, record }">
        <template v-if="column.key === 'action'">
          <TableAction
            :actions="[
              {
                label: '编辑',
                onClick: handleEdit.bind(null, record)
              },
              {
                label: '删除',
                icon: 'ic:outline-delete-outline',
                onClick: handleDelete.bind(null, record)
              },
            ]"
          />
        </template>
      </template>
    </BasicTable>
</template>


<script lang="ts" setup>
import { watch } from 'vue'
import { BasicTable, useTable, BasicColumn, TableAction } from '/@/components/Table';
import { useModal } from '/@/components/Modal';
import SkuEditorModal from './SkuEditorModal.vue';


const columns: BasicColumn[] = [
    {
      title: 'Id',
      dataIndex: 'id',
      ifShow:false
    },
    {
      title: 'SKU名称',
      dataIndex: 'name',
    },
    {
      title: 'Spec路径',
      dataIndex: 'privateSpecName',
      ifShow: (_column) => {
        return true; // 根据业务控制是否显示
      },
    }
  ];

const props = defineProps(
    { 
      tabledata: Array,
      specTemplateJsonData:String
     }
    )
const emit = defineEmits(['update:tabledata'])

const [registerTable,{ setTableData, deleteTableDataRecord }] = useTable({
  title: 'TableAction组件及固定列示例',
  columns: columns,
  bordered: true,
  actionColumn: {
    width: 250,
    title: 'Action',
    dataIndex: 'action',
  },
});

const [registerEditorModal, { openModal:openSkuEditorModal }] = useModal();



watch(()=>props.tabledata,(newV)=>{
  console.log('prop changed',newV)
  setTableData(newV)
})

function handleAddNew(record?: Recordable) {
  //openDrawer(true, {});
  console.log("JJJJ",record)
  openSkuEditorModal(true,{
    skuTemplate:props.specTemplateJsonData,
    skuValue:{}
  })
}

function handleEdit(record: Recordable) {
  console.log('点击了编辑', record);
  openSkuEditorModal(true,{
    skuTemplate:props.specTemplateJsonData,
    skuValue:record?.privateSpecName
  })
}
function handleDelete(record: Recordable) {
  console.log('点击了删除', record);
  deleteTableDataRecord(record.id)
  emit('update:tabledata', props.tabledata)
}

function okClicked(){
  console.log("okc clicked")
}

//methods.setTableData(refP)
</script>