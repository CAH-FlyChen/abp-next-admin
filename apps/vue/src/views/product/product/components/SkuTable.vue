<template>
  <div>
    {{ specTemplateObj }}
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

      <template #body>
        <tr>
          <template v-for="column in dynamicColumns" :key="column.dataIndex">
            <th>{{ column.title }}</th>
            <td>{{ column.dataIndex }}</td>
          </template>
        </tr>
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
import { watch,computed,ref,onMounted } from 'vue'
import type { Ref } from 'vue';
import { BasicTable, useTable, BasicColumn, TableAction } from '/@/components/Table';
import { useModal } from '/@/components/Modal';
import SkuEditorModal from './SkuEditorModal.vue';

const dynamicColumns: Ref<BasicColumn[]> = ref([
    {
      title: 'Id',
      dataIndex: 'id',
      ifShow:false
    },
    // {
    //   title: 'SKU名称',
    //   dataIndex: 'name',
    // },
    // {
    //   title: '规格值',
    //   dataIndex: 'privateSpecName',
    //   ifShow: (_column) => {
    //     return true; // 根据业务控制是否显示
    //   },
    // }
]);

// const columns: BasicColumn[] = [
//     {
//       title: 'Id',
//       dataIndex: 'id',
//       ifShow:false
//     },
//     {
//       title: 'SKU名称',
//       dataIndex: 'name',
//     },
//     {
//       title: '规格值',
//       dataIndex: 'privateSpecName',
//       ifShow: (_column) => {
//         return true; // 根据业务控制是否显示
//       },
//     }
//   ];

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
  title: '',
  columns: dynamicColumns ,
  bordered: true,
  actionColumn: {
    width: 250,
    title: 'Action',
    dataIndex: 'action',
  },
});

const [registerEditorModal, { openModal:openSkuEditorModal, setModalProps,closeModal }] = useModal();

const myTableData = ref([])

watch(()=>props.tabledata,(newV)=>{
  console.log('prop changed',newV)
  //翻译数据
  newV.forEach(e=>{
    if(e.privateSpecName){
      var o = JSON.parse(e.privateSpecName)
      o.GroupTitle = "";
      myTableData.value.push(o)
      console.log("eeeeeeeeeeeeee",myTableData.value)
    }
  })

  setTableData(myTableData.value)
  console.log('prop changed end')
})

watch(()=>props.specTemplateJsonData,(d)=>{
  console.log("specTemplateJsonData start",d)
  var specs = JSON.parse(d)
  var mycolums = new Array()
  //生成colum
  mycolums.push({ title: "组", dataIndex: "GroupTitle" })
  specs.SpecGroups.forEach(e => {
    
    e.Specifications.forEach(t=>{
      if(mycolums.indexOf(t.Title)==-1){
        mycolums.push({ title: t.Title, dataIndex: t.Title })
      }
    })
  });
  mycolums.forEach(e=>{
    dynamicColumns.value.push(e)
  })
  console.log("specTemplateJsonData end",mycolums)
  setTableData(myTableData.value)
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