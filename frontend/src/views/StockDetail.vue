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
    <div>Market Cap: {{stats.marketcap}}</div>
    <div>P/E: {{stats.peRatio}}</div>
</div>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';
import EventBus from '../event-bus.js'

export default {
    name: 'StockDetail',
    components: {
        DefaultLayout,
        EventBus
},
    data() {
        return{
            stockInfo: {},
            image: {},
            stats: {}
        }
 },
    beforeCreate(){
        // let symbol = document.getElementById('search').value;
        EventBus.$on('search-company', function(query) {
            if(query != "" ){
                fetch(`https://cloud.iexapis.com/beta/stock/${query}/company?token=pk_cdd72b15fa2a4735897c36067dd39008`)
                .then((response) => {
                    return response.json();
                })
                .then((resp) => {
                    this.stockInfo = resp;
                    // this.$forceUpdate();
                
                })
                .catch((err) => console.error(err));

                fetch(`https://cloud.iexapis.com/beta/stock/${query}/logo?token=pk_cdd72b15fa2a4735897c36067dd39008`)
                .then((response) => {
                    return response.json();
                })
                .then((resp) => {
                    this.image= resp;
                    // this.$forceUpdate();
                })
                .catch((err) => console.error(err));

                fetch(`https://cloud.iexapis.com/beta/stock/${query}/stats?token=pk_cdd72b15fa2a4735897c36067dd39008`)
                .then((response) => {
                    return response.json();
                })
                .then((resp) => {
                    this.stats= resp;
                    // this.$forceUpdate();
                })
                
                .catch((err) => console.error(err));
                
            }
        })
    }
            
    ,    
    methods:{
       
    }
}

</script>

<style>

</style>