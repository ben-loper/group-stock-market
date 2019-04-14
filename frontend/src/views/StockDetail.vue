<template>
<div>
    <default-layout></default-layout>
    <h1>Stock Detail</h1>
    <div>{{stockInfo.symbol}}</div>
    <div>{{stockInfo.companyName}}</div>
    <div>{{stockInfo.description}}</div>
</div>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';
import auth from '../auth';

export default {
    name: 'StockDetail',
    components: {
        DefaultLayout
},
props:{
  search: String
},
  data() {
    return{
      user: null,
      stockInfo: {}
    }
 },
   beforeMount(){
    this.user = auth.getUser();

  },
    created(){
        //let symbol = document.getElementById('search').value;
        fetch(`https://cloud.iexapis.com/beta/stock/${symbol}/company?token=pk_cdd72b15fa2a4735897c36067dd39008`)
        .then((response) => {
            return response.json();
        })
        .then((resp) => {
            this.stockInfo = resp;
            this.$forceUpdate();
        
        })
        .catch((err) => console.error(err));
        
        },
    methods:{
    }
}
</script>

<style>

</style>