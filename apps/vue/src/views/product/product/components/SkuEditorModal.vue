<template>
  <BasicModal @register="registerModal" v-bind="$attrs" title="编辑SKU" :helpMessage="['提示1', '提示2']" >
    <div v-for="(groupItem) in skuTemplate.SpecGroups" >
      <div style="background-color: yellow">{{ groupItem.Title }}</div>

      <div v-for="specItem in groupItem.Specifications">
        <div>{{ specItem.Title }}</div>
        <a-radio-group  v-model:value="skuValue[specItem.Title]">
          <a-radio v-for="opt in specItem.Options" :value="opt.Title" >{{opt.Title}}</a-radio>
        </a-radio-group>
      </div>
    </div>
  </BasicModal>
</template>
<script lang="ts" setup>
  import { ref,nextTick } from 'vue'
  import { BasicModal, useModalInner } from '/@/components/Modal';


  
  var skuTemplate = ref({specGroups:[]})
  var skuValue = ref({})
  const [registerModal, { changeOkLoading, closeModal }] = useModalInner((data) => {

    nextTick(() => {
       
      skuTemplate.value = JSON.parse(data.skuTemplate);
      console.log("bbb",data.skuValue)
      skuValue.value = JSON.parse(data.skuValue);
      //resetFields();
      //setFieldsValue(data);
    });
  });

  
  function GetSelectedValue(){
    return skuValue.value;
  }

  // defineExpose({
  //   GetSelectedValue
  // })

</script>