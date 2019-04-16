<template>
<div>
    <default-layout></default-layout>
    <h2>Stock Detail</h2>
    <div class="dropdown" style="margin-left: 100px">
        <select v-model="selected">
        <option disabled value="">-- Select One --</option>
        <option v-for="name in names" :key="name.Id" v-bind:value="name.symbol">{{name.symbol}} - {{name.name}}</option>
        </select>
    </div>

    <div class="detail-info">
    <img class="company-logo" v-bind:src="image.url">
    <div class="company-info">
    <div>{{stockInfo.symbol}}</div>
    <div>{{stockInfo.companyName}}</div>
    <div>{{stockInfo.CEO}}</div>
    <div>{{stockInfo.description}}</div>
    <div>{{stockInfo.industry}}</div>
    <div>52-Week Range: {{stats.week52low}} - {{stats.week52high}}</div>
    <div>Shares Outstanding: {{stats.sharesOutstanding}}</div>
    <div>Market Cap: {{stats.marketcap}}</div>
    <div>P/E: {{stats.peRatio}}</div>
    <div>Beta: {{stats.peRatio}}</div>
    <span>YTD Performance: {{stats.ytdChangePercent}}</span>
    <span>30-Day Performance: {{stats.day30ChangePercent}}</span>
    <span>6-Month Performance: {{stats.month6ChangePercent}}</span>
    <span>6-Month Performance: {{stats.year1ChangePercent}}</span>
    </div>
    </div>
</div>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';
import EventBus from '../event-bus.js';
import {globals} from '@/main.js';
import auth from '../auth';

export default {
    name: 'StockDetail',
    components: {
        DefaultLayout
    },
    data() {
        return{
            stockInfo: {},
            image: {},
            stats: {},
            names: [],
            user: null,
            selected: ""
        }
    },
    watch: {
        selected(vm) {
            return this.GetApiData(vm);
        }
    },
      beforeMount(){
        this.user = auth.getUser();

        },
    created() {
        fetch(`${process.env.VUE_APP_REMOTE_API}/api/Company/`, {
        method: 'GET',
        headers: {
            Authorization: 'Bearer ' + auth.getToken(),
        },
        credentials: 'same-origin',
        })
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            this.names = data;
        })
        .catch((err) => console.error(err)); 
    },  
    methods:{
        GetApiData(symbol){
            if(symbol != "") {
                fetch(`https://cloud.iexapis.com/beta/stock/${symbol}/company?token=pk_cdd72b15fa2a4735897c36067dd39008`)
                .then((response) => {
                    return response.json();
                })
                .then((resp) => {
                    this.stockInfo = resp;
                    // this.$forceUpdate();
                
                })
                .catch((err) => console.error(err));

                fetch(`https://cloud.iexapis.com/beta/stock/${symbol}/logo?token=pk_cdd72b15fa2a4735897c36067dd39008`)
                .then((response) => {
                    return response.json();
                })
                .then((resp) => {
                    this.image= resp;
                    // this.$forceUpdate();
                })
                .catch((err) => console.error(err));

                fetch(`https://cloud.iexapis.com/beta/stock/${symbol}/stats?token=pk_cdd72b15fa2a4735897c36067dd39008`)
                .then((response) => {
                    return response.json();
                })
                .then((resp) => {
                    this.stats= resp;
                    // this.$forceUpdate();
                })            
                .catch((err) => console.error(err));
            }
        }
       
    }
}
</script>

<style>
.detail-info {
    margin-left: 2%;
}

.dropdown {
    margin-left: 2% !important;
    margin-bottom: 2%;
    margin-top: 1%;
}

.company-logo {
    width: 15%;
    height: 75%;
    border: 2px solid black;
    border-radius: 5px;
    margin-right: 3%;
    margin-top: 2.5%;
    padding: 0.5%;
}

.detail-info {
    display: flex;
}
</style>