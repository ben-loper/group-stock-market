<template>
  <default-layout>
    <div id="portfolio">
      <h1>Portfolio Page</h1> 
      <p>Hello! {{user.fName}}</p>     
    </div>
  </default-layout>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';
import auth from '../auth';

export default {
  name: 'ListPortfolio',
  components: {
    DefaultLayout
  },
  data() {
    return{
      user: null
    }
  },
  beforeMount(){
    this.user = auth.getUser();

  }

}
</script>

<style>
button {
  margin-right: 5px !important;
}
span.badge {
  margin-right: 5px;
}
.actions .btn {
  margin-top: 0px;
}
</style>