<template>
  <span>
    sku editor 
    <!-- {{ text }} &nbsp; -->
    <!-- <a-cascader v-model:value="casecadeValue" :options="options" @change="onChange">
      <a href="#">修改</a>
    </a-cascader> -->
  </span>
</template>

<script lang="ts" setup>
import { defineEmits ,defineProps, ref  } from 'vue';
import { getAll } from '/@/api/system/regions';
import { listToTree } from '/@/utils/helper/treeHelper';

interface Option {
  value: string;
  label: string;
  children?: Option[];
  code?: number;
  [key: string]: any;
}

interface ILocation{
  countryCode:string,
  provinceCode:string,
  cityCode:string,
  districtCode:string,
}

var props = defineProps({
     value:{
       type: Object as PropType<ILocation>
     }
})


var emits = defineEmits(['change'])

const casecadeValue = ref<string[]>([]);
const text = ref<string>('未选择');
const options = ref<Option[]>([])

getAll({containsCountry:false}).then((rData)=>{
  rData.items.forEach((e)=>{
    var d = e as any;
    d.label = d.name;
    d.value = d.code; 
  })
  var treeData = listToTree(rData.items, {
      id: 'code',
      pid: 'parentCode',
    });
  options.value = treeData;
  if(props.value)
  {
    console.log('props.value exist')
    casecadeValue.value = [props.value.provinceCode,props.value.cityCode,props.value.districtCode]

    var p = rData.items.find(t=>t.code==props.value.provinceCode)?.name
    var c = rData.items.find(t=>t.code==props.value.cityCode)?.name
    var d = rData.items.find(t=>t.code==props.value.districtCode)?.name
    text.value = p+","+c+","+d;
  }
  else
  {
    console.log('props.value not exist')
  }
    
});


const onChange = (value: string, selectedOptions: Option[]) => {
  console.log(value)
  text.value = selectedOptions.map(o => o.label).join(', ');
  var obj:ILocation = {
    countryCode:'CN',
    provinceCode:value[0],
    cityCode : value[1],
    districtCode : value[2]
  }
  //通知父模型变更
  emits('change',obj);
};

  defineExpose({
      text,
      options,
      onChange,
  });


</script>

