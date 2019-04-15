<template>
    
    <div id="landing">
        <default-layout></default-layout>

        <div>    
            <h2 style="float: left; margin-left: 10%; width: 35%;">What IS Stockr?</h2>
            <h2 style="margin-left: 55%; margin-right: 10%;">Market News</h2>
        </div>

                <div id="description">
                    Stockr is the world's greatest stock purchasing/tracking application.
                    You can manage your portfolio, buy and sell stocks, follow favorites, and more!
                    Over three people worldwide are getting things done with Stockr. What will YOU do?
                </div>
            
                <div id="marketNews">
                    Here is the space where market news type stuff will go! I've filled out this space
                    with additional words and stuff just so it'll kind of be the size that we want it
                    to be. Thank you for reading this message.
                </div>

        <h2 style="margin-left: 30%; margin-right: 30%; margin-top: 40pt;">
            <center style="margin-top: 50pt;">Hot Stocks</center>
        </h2>

                <div id="marketStuff">
                    <table class="table table-striped">
                        <thead class="thead-dark"><tr>
                            <th scope="col">Symbol</th>
                            <th scope="col">Price</th></tr></thead>
                        <tr v-for="stock in hotStocks" :key="stock.name">
                            <td>{{stock.name}}</td>
                            <td>{{stock.price}}</td>
                        </tr>
                    </table>
                </div>
        
    </div>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';

export default {
    name: 'Landing',
    components: {
        DefaultLayout,
  },
data() {
    return { hotStocks : '' }
},
created() {

fetch(`https://cloud.iexapis.com/beta/tops?token=pk_cdd72b15fa2a4735897c36067dd39008&symbols=aapl`)
  .then((resp) => {
    return resp.json();
  })
  .then((resp) => {
    alert(JSON.stringify(resp))
    this.hotStocks = resp.map(stock =>{
        return { name: stock.symbol, price: stock.lastSalePrice };
    });
    return resp;
  });
}
};


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

template {
    background-color: #f5f5f5;
}

#marketStuff {
    border-style: solid;
    border-width: 2px;
    border-radius: 5px;
    margin-left: 30%;
    margin-right: 30%;
}

#description {
    border-style: solid;
    border-width: 2px;
    border-radius: 5px;
    float: left;
    margin-left: 10%;
    width: 35%;
}

#marketNews {
    border-style: solid;
    border-width: 2px;
    border-radius: 5px;
    margin-left: 55%;
    margin-right: 10%;
}

#logo {
    width: 300px;
    height: auto;
    padding-bottom: 10pt;
    padding-top: 10pt;
    margin-bottom: 10pt;
}

</style>
