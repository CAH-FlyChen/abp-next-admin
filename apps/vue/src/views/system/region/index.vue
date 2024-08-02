<template>
  <RegionTable />
</template>

<script lang="ts">
  import { defineComponent } from 'vue';

  import RegionTable from './components/RegionTable.vue';
  export default defineComponent({
    name: 'Menus',
    components: {
      RegionTable,
    },
    setup() {},
  });
</script>
