<template>
  <default-layout>
      <h2 class="portfolio-h2">Your Portfolio</h2>  
        <div id="portfolio-table">
          <table class="table table-striped">
          <thead class="thead-dark">
          <tr>
            <th scope="col">Symbol</th>
            <th scope="col">Number of Shares</th>
            <th scope="col">Current Price</th>
            <th scope="col">Total Market Value</th>
            <th scope="col"> +/-</th>
            <th scope="col"></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="stock in portfolio" :key="stock.Id">
            <td>{{ stock.symbol }}</td>
            <td>{{ stock.numberOfShares }}</td>
            <td>${{parseFloat(stock.price).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ",") }}</td>
            <td>${{parseFloat(CalculateMarketValue(stock.price, stock.numberOfShares)).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ",")}}</td>
            <td :class="(CalculateMarketValue(stock.price, stock.numberOfShares) - stock.paidInvestments) >= 0 ? 'good' : 'bad'">${{parseFloat(CalculateMarketValue(stock.price, stock.numberOfShares) - stock.paidInvestments).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ",")}}</td>
            <td>
                <button class="btn btn-success" :value="stock.symbol" @click="BuyShares($event)">Buy</button>
                <button class="btn btn-danger" :value="stock.symbol" @click="SellShares($event)">Sell</button>              
            <!-- <td class="align-middle"></td> -->
            </td>
          </tr>
        </tbody>
      </table>
        </div>
  </default-layout>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';
import auth from '../auth';
import {globals} from '@/main.js';
import { constants } from 'crypto';

export default {
  name: 'ListPortfolio',
  components: {
    DefaultLayout
  },
methods: {
  
BuyShares(event){
  globals.symbol = event.target.value;
  
  globals.isBuy = true;
  this.$router.push({name:'trades'});
},
SellShares(event){
  
  globals.numberOfShares = event.path[2].childNodes[1].innerText;
  globals.symbol = event.target.value;
  globals.isBuy = false;
  this.$router.push({name:'trades'});
},

GetCurrentPrice(stock){
  fetch(`https://cloud.iexapis.com/beta/stock/${stock.symbol}/price?token=pk_cdd72b15fa2a4735897c36067dd39008`)
  .then((response) => {
    return response.text();
  })
  .then((resp) => {
    stock.price = resp;
    this.$forceUpdate();
  });
},
CalculateMarketValue(price, shares) {
  let marketValue = price * shares;
  return marketValue;
},
CalculateTotalInvestment(transactions) {
  for(let i = 0; i < transactions.length; i++){
    
      let calculatedValue = transactions[i].numOfShares * transactions[i].price;

      if(transactions[i].symbol in this.totalValues){
        
        let previousTotal = this.totalValues[transactions[i].symbol];

        this.totalValues[transactions[i].symbol] = previousTotal + calculatedValue;
      }
      else{
        this.totalValues[transactions[i].symbol] = calculatedValue;
      }
      
  }
  for(let item in this.totalValues){
        let stockInfo = {};
        stockInfo.symbol = item;
        stockInfo.totalValue = this.totalValues[item];
        this.valuePerSymbol.push(stockInfo);
      }

  
},
GetTotalValues(){
  fetch(`${process.env.VUE_APP_REMOTE_API}/api/BuySell/AllTransactions`, {
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
        this.transactions = data;
        this.CalculateTotalInvestment(this.transactions);

        for(let i = 0; i < this.portfolio.length; i++){
          for(let j = 0; j < this.valuePerSymbol.length; j++){
            if(this.portfolio[i].symbol == this.valuePerSymbol[j].symbol){

              this.portfolio[i].paidInvestments = this.valuePerSymbol[j].totalValue;           
            
          }
        }
        console.log(this.portfolio);
      }
      })
      .catch((err) => console.error(err));
}
},
  data() {
    return{
      user: null,
      portfolio: [],
      transactions: {},
      totalValues: [],
      valuePerSymbol: []
    }
  }
  ,
  beforeMount(){
    this.user = auth.getUser();
    
  },
    created() {
    fetch(`${process.env.VUE_APP_REMOTE_API}/api/BuySell/`, {
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
        this.portfolio = data;
        //need to loop through portfolio for each symbol
        data.forEach(stock => {
          this.GetCurrentPrice(stock);
        })
        // GetCurrentPrice(data.symbol);
      })
      .then(() => {
        this.GetTotalValues();
      })
      .catch((err) => console.error(err));
  }
}
</script>

<style scoped>
button {
  margin-top: 0px !important;
  padding-left: 10px;
  padding-right: 10px !important;
}

th {
  color: #bffbfb !important;
}

table {
  text-align: center;
}

.table > tbody > tr > td {
  vertical-align: middle;
}

#portfolio-table {
    border: 2px solid black;
    border-radius: 5px !important;
}

.portfolio-h2 {
  margin-left: 0%;
  margin-bottom: 1%;
}
</style>