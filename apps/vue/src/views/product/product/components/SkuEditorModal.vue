<template>
  <BasicModal @register="registerModal" v-bind="$attrs" title="编辑SKU" :helpMessage="['提示1', '提示2']" >
    <div v-for="(groupItem) in props.specTemplateObj?.SpecGroups" >
      <div style="background-color: yellow">{{ groupItem.Title }}</div>
      <div>SKU名称 <a-input v-model:value="record.name" placeholder="SKU名称" /></div>
      <div v-for="specItem in groupItem.Specifications">
        <div>{{ specItem.Title }}</div>

        <a-radio-group  v-model:value="selectedValueObj[specItem.Title ]">
          <a-radio v-for="opt in specItem.Options" :value="opt.Title" >{{opt.Title}}</a-radio>
        </a-radio-group>
        
      </div>
    </div>
  </BasicModal>
</template>
<script lang="ts" setup>
  import { ref,nextTick,computed ,watch , isRef ,isReactive} from 'vue'
  import { BasicModal, useModalInner } from '/@/components/Modal';

  var props = defineProps({
    specTemplateObj:{
      type:Object,
      default:{SpecGroups:[]}
    }
  })
  const selectedValueObj = ref({})
  var record = {name:""};
  var mode = null;
  watch(
    selectedValueObj,
    (newV)=>{
      if(record!=null){
        record.privateSpecName = JSON.stringify(newV);
        console.log(record.privateSpecName)
        record.name=""
        var keys = new Array()
        for (const k in newV) {
          keys.push(k)
        }
        keys.sort()
        console.log(keys)
        keys.forEach(function (k) {
          record.name += "|"+k+"|"+ newV[k]
        });
        if(record.name.length>0)
          record.name = record.name.substring(1)
      }
    },
    {
      deep: true
    }
  )

  function GetData(){
    return {
      mode:mode,
      data:{
        selectedValueJson: JSON.stringify(selectedValueObj),
        name:record.name
      }
    }
  }

  const [registerModal, { changeOkLoading, closeModal }] = useModalInner((data) => {

    nextTick(() => {
      mode = data.mode
      if(data.mode==="add"){
        record =  {name:""}
        selectedValueObj.value = {}
      }
      else if(data.mode=="edit"){
        record = data.record //reactive对象
        selectedValueObj.value = JSON.parse(record.privateSpecName)
      }
    });
  });

  defineExpose({
    GetData
  })
</script>