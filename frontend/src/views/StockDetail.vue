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

    <div v-if="stockInfo.companyName != null" class="detail-info">
    <img class="company-logo" v-bind:src="image.url">
    <div class="company-info">
    <div class="basic-info">
    <h5><strong>{{stockInfo.companyName}} | {{stockInfo.symbol}}</strong></h5>
    <div><strong> CEO: </strong>{{stockInfo.CEO}}</div>
    <div><strong> Description: </strong>{{stockInfo.description}}</div>
    <div><strong> Industry: </strong>{{stockInfo.industry}}</div>
    <div><strong> 52-Week Range: </strong>${{stats.week52low}} -{{stats.week52high}}</div>
    </div>
    <div class="performance-info">
    <div><strong> Shares Outstanding: </strong>{{stats.sharesOutstanding}}</div>
    <div><strong> Market Cap: </strong>{{stats.marketcap}}</div>
    <div><strong> P/E: </strong>{{stats.peRatio}}</div>
    <div><strong> Beta: </strong>{{(stats.beta.toFixed(2))}}</div>
    <div><strong> YTD Performance: </strong>
    <span v-bind:class="{'good': ((parseFloat(this.stats.ytdChangePercent)*100).toFixed(2)) > 0}">{{((parseFloat(this.stats.ytdChangePercent)*100).toFixed(2))}}%</span></div>
    <div><strong> 30-Day Performance: </strong>{{((parseFloat(this.stats.day30ChangePercent)*100).toFixed(2))}}%</div>
    <div><strong> 6-Month Performance: </strong>{{((parseFloat(this.stats.month6ChangePercent)*100).toFixed(2))}}%</div>
    <div><strong> 12-Month Performance: </strong>{{((parseFloat(this.stats.year1ChangePercent)*100).toFixed(2))}}%</div>
    </div>
    </div>
    </div>
    <h5 v-if="stockInfo.companyName != null" class="current-price">Current Price: ${{price}}</h5>
    <button v-if="stockInfo.companyName != null" class="btn" id="button" :value="stockInfo.symbol" @click="BuyShares($event)">Buy</button>   
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
            selected: "",
            price: {},
            returnYTD: 0
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

                fetch(`https://cloud.iexapis.com/beta/stock/${symbol}/price?token=pk_cdd72b15fa2a4735897c36067dd39008`)
                .then((response) => {
                    return response.text();
                })
                .then((resp) => {
                    this.price = resp;
                });

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
        },
        BuyShares(event){
            console.log("We did it.");
            globals.symbol = event.target.value;
            globals.isBuy = true;
            this.$router.push({name:'trades'});
}
       
    }
}
</script>

<style>
.good{
    color: green;
}

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
    width: 60%;
}

.basic-info {
    width: 50%;
    margin-right: 1.5%;
    padding-left: 2%;
}

.performance-info {
    width: 50%;
    padding-left: 1%;
}

#button {
    background-color: #611aa6 !important;
    border: 1px solid #611aa6 !important;
    color: white;
    margin-left: 15.5% !important;
    width: 9%;
}

.current-price {
    margin-left: 13.6%;
}
</style>