<template>
  <div class="container-fluid">
    <authorized-navigation v-if="isAuthorized"></authorized-navigation>
    <unauthorized-nav v-else></unauthorized-nav>
    <div class="page-view">
      <slot />
    </div>
  </div>
</template>

<script>
import AuthorizedNavigation from '@/components/AuthorizedNavigation';
import UnauthorizedNav from '@/components/UnauthorizedNav';
import auth from '../auth';

export default {
  name: 'DefaultLayout',
  data() {
    return {
      isAuthorized: false
    }
  },
  components: {
    AuthorizedNavigation,
    UnauthorizedNav,
    auth
  },
  beforeMount(){

    let user = auth.getUser();

    if(user != null){
      this.isAuthorized = true;
    }
  }
};
</script>

<style>
.container-fluid {
  margin: 0px;
  padding: 0px !important;
}
.page-view {
  padding: 0px 20px !important;
}
</style>
