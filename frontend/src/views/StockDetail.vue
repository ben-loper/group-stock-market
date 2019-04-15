<template>
<div>
    <default-layout></default-layout>
    <h2>Stock Detail</h2>
    <div class="detail-info">
    <div>{{stockInfo.symbol}}</div>
    <div>{{stockInfo.companyName}}</div>
    <div>{{stockInfo.description}}</div>
    <img v-bind:src="image.url">
    <div>52-Week Range: {{stats.week52low}} - {{stats.week52high}}</div>
    <div>Shares Outstanding: {{stats.sharesOutstanding}}</div>
    <div>Market Cap: {{stats.marketcap}}</div>
    <div>P/E: {{stats.peRatio}}</div>
    </div>
</div>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';
import EventBus from '../event-bus.js';
import {globals} from '@/main.js';

export default {
    name: 'StockDetail',
    components: {
        DefaultLayout
    },
    data() {
        return{
            stockInfo: {},
            image: {},
            stats: {}
        }
    },
    computed: {
        image(vm) {
            return GetImage(globals.search);
        }
    },
    // beforeCreate(){
    //     EventBus.$on('search-company', this.GetApiData);
    // },    
    methods:{
        GetImage(symbol) {
            if(globals.search != "") {
                fetch(`https://cloud.iexapis.com/beta/stock/${globals.search}/company?token=pk_cdd72b15fa2a4735897c36067dd39008`)
                .then((response) => {
                    return response.json();
                })
                .then((resp) => {
                    this.stockInfo = resp;
                    // this.$forceUpdate();
                
                })
                .catch((err) => console.error(err));
            }
        }
        // GetApiData(){
        //     if(globals.search != "") {
        //         fetch(`https://cloud.iexapis.com/beta/stock/${globals.search}/company?token=pk_cdd72b15fa2a4735897c36067dd39008`)
        //         .then((response) => {
        //             return response.json();
        //         })
        //         .then((resp) => {
        //             this.stockInfo = resp;
        //             // this.$forceUpdate();
                
        //         })
        //         .catch((err) => console.error(err));

        //         fetch(`https://cloud.iexapis.com/beta/stock/${globals.search}/logo?token=pk_cdd72b15fa2a4735897c36067dd39008`)
        //         .then((response) => {
        //             return response.json();
        //         })
        //         .then((resp) => {
        //             this.image= resp;
        //             // this.$forceUpdate();
        //         })
        //         .catch((err) => console.error(err));

        //         fetch(`https://cloud.iexapis.com/beta/stock/${globals.search}/stats?token=pk_cdd72b15fa2a4735897c36067dd39008`)
        //         .then((response) => {
        //             return response.json();
        //         })
        //         .then((resp) => {
        //             this.stats= resp;
        //             // this.$forceUpdate();
        //         })            
        //         .catch((err) => console.error(err));
        //     }
        // }
       
    }
}
</script>

<style>
.detail-info {
    margin-left: 2%;
}
</style>