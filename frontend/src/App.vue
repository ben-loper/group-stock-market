<template>
  <div id="app">
    <transition name="fade" mode="out-in">
      
      <router-view></router-view>
    </transition>
  </div>
</template>

<script>
export default {
  name: 'app',
  components: {},
    methods: {
      // handleSearch(query) {
      //   //console.log('Filter Tasks: ', query);
      //   this.search = query;
    }
,
data() {
  return {
    search: ''
  }
}

};
</script>

<style>
#app {
  font-family: 'Acme', sans-serif;
  margin: 0px;
  padding: 0px;
}
.fade-enter-active,
.fade-leave-active {
  transition-duration: 0.3s;
  transition-property: opacity;
  transition-timing-function: ease;
}
.fade-enter,
.fade-leave-active {
  opacity: 0;
}
</style>
