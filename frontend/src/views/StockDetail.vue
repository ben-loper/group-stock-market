<template>
<div>
    <default-layout></default-layout>
    <h1>Stock Detail</h1>
    <div>{{stockInfo.symbol}}</div>
    <div>{{stockInfo.companyName}}</div>
    <div>{{stockInfo.description}}</div>
    <img v-bind:src="image.url">
    <div>52-Week Range: {{stats.week52low}} - {{stats.week52high}}</div>
    <div>Shares Outstanding: {{stats.sharesOutstanding}}</div>
    <div>Beta: {{stats.beta}}</div>
    <div>P/E: {{stats.peRatio}}</div>
    <div>P/S: {{stats.priceToSales}}</div>
    <div>P/B: {{stats.priceToBook}}</div>
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
      stockInfo: {},
      image: {},
      stats: {}
    }
 },
   beforeMount(){
    this.user = auth.getUser();

  },
    created(){
        //let symbol = document.getElementById('search').value;
        fetch(`https://cloud.iexapis.com/beta/stock/aapl/company?token=pk_cdd72b15fa2a4735897c36067dd39008`)
        .then((response) => {
            return response.json();
        })
        .then((resp) => {
            this.stockInfo = resp;
            this.$forceUpdate();
        
        })
        .catch((err) => console.error(err));

        fetch(`https://cloud.iexapis.com/beta/stock/aapl/logo?token=pk_cdd72b15fa2a4735897c36067dd39008`)
        .then((response) => {
            return response.json();
        })
        .then((resp) => {
            this.image= resp;
            this.$forceUpdate();
        })
        .catch((err) => console.error(err));

        fetch(`https://cloud.iexapis.com/beta/stock/aapl/advanced-stats?token=pk_cdd72b15fa2a4735897c36067dd39008`)
        .then((response) => {
            return response.json();
        })
        .then((resp) => {
            this.stats= resp;
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