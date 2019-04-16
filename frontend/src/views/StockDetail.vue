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
    <div class="basic-info">
    <div><strong> Name: </strong>{{stockInfo.companyName}}</div>
    <div><strong> Symbol: </strong>{{stockInfo.symbol}}</div>
    <div><strong> CEO: </strong>{{stockInfo.CEO}}</div>
    <div><strong> Description: </strong>{{stockInfo.description}}</div>
    <div><strong> Industry: </strong>{{stockInfo.industry}}</div>
    <div><strong> 52-Week Range: </strong>{{stats.week52low}} - {{stats.week52high}}</div>
    <div><strong> Shares Outstanding: </strong>{{stats.sharesOutstanding}}</div>
    </div>
    <div class="performance-info">
    <div><strong> Market Cap: </strong>{{stats.marketcap}}</div>
    <div><strong> P/E: </strong>{{stats.peRatio}}</div>
    <div><strong> Beta: </strong>{{stats.peRatio}}</div>
    <div><strong> YTD Performance: </strong>{{stats.ytdChangePercent}}</div>
    <div><strong> 30-Day Performance: </strong>{{stats.day30ChangePercent}}</div>
    <div><strong> 6-Month Performance: </strong>{{stats.month6ChangePercent}}</div>
    <div><strong> 6-Month Performance: </strong>{{stats.year1ChangePercent}}</div>
    </div>
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
    padding: 0.5%;
}

.detail-info {
    display: flex;
    justify-content: center;
}

.company-info {
    display: flex;
}

.basic-info {
    width: 50%;
    margin-right: 2%;
    padding-left: 2%;
}

.performance-info {
    width: 50%;
}
</style>