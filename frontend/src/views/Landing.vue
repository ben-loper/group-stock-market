<template>
    
    <div id="landing">
        <default-layout></default-layout>
        <center>
            <img src="../assets/Stockrlogo.png" id="logo" />
        </center>
    
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
                    Here's where the market stuff would go. There should be like maybe a carousel of top stocks
                    rotating through right here or some such thing.
                </div>
        
    </div>
</template>

<script>
import DefaultLayout from '@/layouts/DefaultLayout';

export default {
    name: 'Landing',
    components: {
        DefaultLayout,
  }
}

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
