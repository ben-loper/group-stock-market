<template>
    
    <div id="landing">
        <default-layout></default-layout>

        <div>    
            <h2 style="float: left; margin-left: 15%;">What IS Stockr?</h2>
            <h2 style="margin-left: 64%; margin-right: 21%;">Market News</h2>
        </div>
            <div id="leftColumn">
                <div id="description">
                    Stockr is the world's greatest stock purchasing/tracking application.
                    You can manage your portfolio, buy and sell stocks, follow favorites, and more!
                    Over three people worldwide are getting things done with Stockr. What will YOU do?
                </div>
            </div>
            
                <div id="marketNews">
                    <vue-rss-feed :feedUrl="feedUrl" :name="name" :limit="limit"/>
                </div>

                <h2 style="margin-left: 17%; margin-right: 70%; position: relative; top: -355px;">
                    Hot Stocks
                </h2>

                <div id="marketStuff">
                    <table class="table table-striped">
                        <thead class="thead-dark">
                            <tr>
                                <th scope="col">Symbol</th>
                                <th scope="col">Price</th>
                            </tr>
                        </thead>
                        <tr v-for="stock in hotStocks" :key="stock.name">
                            <td>{{ stock[0].name }}</td>
                            <td>{{ stock[0].price }}</td>
                        </tr>
                    </table>
                </div>
        
    </div>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';
import VueRssFeed from "vue-rss-feed";

export default {
    name: 'Landing',
    components: {
        DefaultLayout,
        VueRssFeed,
  },

data() {
    return{
        hotStocks : [],
        feedUrl: `https://cors-anywhere.herokuapp.com/http://rss.cnn.com/rss/money_markets.rss`,
        name: "",
        limit: 10
    }
},

created() {

var topStocks = ['AAPL', 'FB', 'MSFT', 'BA', 'JPM']
let x = 0;

topStocks.forEach(item => {
fetch(`https://cloud.iexapis.com/beta/tops?token=pk_cdd72b15fa2a4735897c36067dd39008&symbols=${item}`)
  .then((resp) => {
    return resp.json();
  })
  .then((resp) => {
    this.hotStocks[x] = resp.map(stock =>{
        return { name: stock.symbol, price: stock.lastSalePrice };
    });
    x++;
    this.$forceUpdate();
    return resp;
  });
});
}
}


//     let dummyData = [
//   {
//     "symbol": "SNAP",
//     "bidSize": 200,
//     "bidPrice": 110.94,
//     "askSize": 100,
//     "askPrice": 111.82,
//     "volume": 177265,
//     "lastSalePrice": 111.76,
//     "lastSaleSize": 5,
//     "lastSaleTime": 1480446905681,
//     "lastUpdated": 1480446910557,
//     "sector": "softwareservices",
//     "securityType": "commonstock"
//   },
//   {
//     "symbol": "FB",
//     "bidSize": 200,
//     "bidPrice": 120.8,
//     "askSize": 100,
//     "askPrice": 122.5,
//     "volume": 205208,
//     "lastSalePrice": 121.41,
//     "lastSaleSize": 100,
//     "lastSaleTime": 1480446908666,
//     "lastUpdated": 1480446923942,
//     "sector": "softwareservices",
//     "securityType": "commonstock"
//   },
//   {
//     "symbol": "AIG+",
//     "bidSize": 0,
//     "bidPrice": 0,
//     "askSize": 0,
//     "askPrice": 0,
//     "volume": 3400,
//     "lastSalePrice": 21.52,
//     "lastSaleSize": 100,
//     "lastSaleTime": 1480446206461,
//     "lastUpdated": -1,
//     "sector": "insurance",
//     "securityType": "commonstock"
//   }

// ];

//         this.hotStocks = dummyData.map(stock => {
//         return { name: stock.symbol, price: stock.lastSalePrice };
//     });
//     return resp;
// });

// }
// }

</script>

<style>

html {
    background-color: #f5f5f5;
    background-image: url("../assets/wallstreet-bull.jpg");
    background-repeat: no-repeat;
    background-size: cover;
    background-position: 5%;
}

#marketStuff {
    border-style: solid;
    border-width: 2px;
    border-radius: 5px;
    margin-left: 2%;
    float: left;
    width: 42%;
    margin-bottom: 10pt;
    position: relative;
    top: -355px;
    background-color: #f5f5f5;
}

#description {
    border-style: solid;
    border-width: 2px;
    border-radius: 5px;
    float: left;
    margin-left: 2%;
    width: 42%;
    padding: 10px;
    background-color: #f5f5f5;
}

#marketNews {
    border-style: solid;
    border-width: 2px;
    border-radius: 5px;
    margin-left: 46%;
    margin-right: 2%;
    padding: 10px;
    height: 350pt;
    overflow-y: scroll;
    background-color: #f5f5f5;
}

h2 {
    background-color: #f5f5f5;
    padding: 0.5%;
    border: 2px solid black;
    border-radius: 5px;
    text-align: center;
}

h2>div {
    background-color: #f5f5f5;
    padding: 0.5%;
    border: 2px solid black;
    border-radius: 5px;
}
</style>
