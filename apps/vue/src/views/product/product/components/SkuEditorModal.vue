<template>
  <BasicModal @register="registerModal" v-bind="$attrs" title="编辑SKU" :helpMessage="['提示1', '提示2']" >
    <div v-for="(groupItem) in props.specTemplateObj?.SpecGroups" >
      <div style="background-color: yellow">{{ groupItem.Title }}</div>

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
  import { ref,nextTick,computed ,watch} from 'vue'
  import { BasicModal, useModalInner } from '/@/components/Modal';


  const emits = defineEmits(['update:selectedJsonValue','update:test'])

  // const value = ref<number>(1);

  const selectedValueObj = ref({})

  var props = defineProps({
    specTemplateObj:{
      type:Object,
      default:{SpecGroups:[]}
    },
    selectedJsonValue:String,
    test:String
  })

  // watch(()=>props.selectedJsonValue,(newV)=>{
  //   selectedValueObj.value = JSON.parse(newV)
  // })

  watch(
    selectedValueObj,
    (newV)=>{
      var d = JSON.stringify(newV);
      console.log("prop changed to and fire",newV);
      emits('update:selectedJsonValue', d)
    },
    {
      deep: true
    }
  )



  // const selectedValueObj = computed({
  //     get() {
  //       if(props.selectedJsonValue) return JSON.parse(props.selectedJsonValue)
  //       return {}
  //     },
  //     set(value) {
  //       console.log('vvvvvvvvvvvvvvvvvvv',value)
  //     }
  //   });

  const [registerModal, { changeOkLoading, closeModal }] = useModalInner((data) => {

    nextTick(() => {
      // skuTemplate.value = JSON.parse(data.skuTemplate);
      // console.log("bbb",data.skuValue)
      //skuValue.value = JSON.parse(data.skuValue);
      //resetFields();
      //setFieldsValue(data);
      selectedValueObj.value = JSON.parse(props.selectedJsonValue)
    });
  });



  // defineExpose({
  //   GetSelectedValue
  // })

</script>