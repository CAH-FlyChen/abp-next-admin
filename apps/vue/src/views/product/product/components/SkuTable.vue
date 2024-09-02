<template>
  <div>
    <SkuEditorModal 
      ref="elSku"
      @register="registerEditorModal" 
      @ok="okClicked"
      :specTemplateObj="specTemplateObj"
      />
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
import { watch,computed,ref } from 'vue'
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
      title: '规格值',
      dataIndex: 'privateSpecName',
      ifShow: (_column) => {
        return true; // 根据业务控制是否显示
      },
    }
  ];

const elSku = ref()  
const props = defineProps(
    { 
      tabledata: Array,
      specTemplateJsonData:String
     }
    )
const emit = defineEmits(['update:tabledata'])

const specTemplateObj = computed(() => { 
  if(props.specTemplateJsonData) return JSON.parse(props.specTemplateJsonData)
  return {}
})

const [registerTable,{ setTableData, deleteTableDataRecord,insertTableDataRecord,updateTableDataRecord }] = useTable({
  title: 'TableAction组件及固定列示例',
  columns: columns,
  bordered: true,
  actionColumn: {
    width: 250,
    title: 'Action',
    dataIndex: 'action',
  },
});

const [registerEditorModal, { openModal:openSkuEditorModal, setModalProps,closeModal }] = useModal();



watch(()=>props.tabledata,(newV)=>{
  console.log('prop changed',newV)
  setTableData(newV)
})

function handleAddNew(record?: Recordable) {
  //openDrawer(true, {});
  console.log("record on add is",record)
  openSkuEditorModal(true,{
    mode:"add",
    record:{}
  })
}

function handleEdit(record: Recordable) {
  console.log('点击了编辑', record);
  openSkuEditorModal(true,{
    mode:"edit",
    record:record
  })
}
function handleDelete(record: Recordable) {
  console.log('点击了删除', record);
  deleteTableDataRecord(record.id)
  emit('update:tabledata', props.tabledata)
}

function okClicked(e){
  console.log("okc clicked",elSku.value.GetData())
  var modalReturnData = elSku.value.GetData()
  var record = modalReturnData.record;//上面传入，这里传出
  record.PrivateSpecName = modalReturnData.data.selectedValueJson.value

  if(modalReturnData.mode==="add"){
    //insert  record
    insertTableDataRecord(record)
    emit('update:tabledata', props.tabledata)
  }
  else{
    //update
    updateTableDataRecord(record.name,record)
    emit('update:tabledata', props.tabledata)
  }
  closeModal()
}

//methods.setTableData(refP)
</script>