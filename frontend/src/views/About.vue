<template>
    <div>
        <default-layout></default-layout>
        <h2>Our Story</h2>
        <div class="story-text">
        <h5>Coming from previous careers in pharmaceutical/tech sales, mutual fund accounting, QA software testing, and retail sales management, we enrolled at 
            Tech Elevator with the hopes of forging new paths as software developers. Over the past 14 weeks, we've learned a tremendous amount of technical skills and 
            fostered new relationships with each other that are sure to last a lifetime. Upon graduation from the program, we'll all venture off into our new careers 
            as junior developers at various companies in the Greater Cincinnati area. We designed STOCKR to be a culmination of our full education here at Tech Elevator, 
            and hope that you share in our excitement of its creation by making use of it to help manage your stock portfolios in the future. </h5>
        </div>
        <div class="image-container"> 
            <div class="our-image">
            <img src="../assets/Adam-stockr.jpg" />
            </div>
            <div class="our-image" id="john-image">
            <img src="../assets/John-stockr.jpg" />
            </div>
            <div class="our-image">
            <img src="../assets/Ben-stockr.jpg" />
            </div>
            <div class="our-image" id="josh-image">
            <img src="../assets/Josh-stockr.jpg" />
            </div>
        </div>
        <div class="linkedin-container">
            <div class="linkedin-image">
            <a href="https://www.linkedin.com/in/adamjsmith7411/" target="_blank"><img src="../assets/linkedin-logo.png" /></a>
            </div>
            <div class="linkedin-image">
            <a href="https://www.linkedin.com/in/wunderlejohn/" target="_blank"><img src="../assets/linkedin-logo.png" /></a>
            </div>
            <div class="linkedin-image">
            <a href="https://www.linkedin.com/in/benjamin-loper/" target="_blank"><img src="../assets/linkedin-logo.png" /></a>
            </div>
            <div class="linkedin-image">
            <a href="https://www.linkedin.com/in/joshuamolczyk/" target="_blank"><img src="../assets/linkedin-logo.png" /></a>
            </div>
        </div>
    </div>
</template>

<script>

import DefaultLayout from '@/layouts/DefaultLayout';

export default {
    name: 'About',
    components: {
        DefaultLayout,
  }

}
</script>

<style>
.story-text {
    display: flex;
    width: 94%;
    margin-left: 2%;
    margin-right: 2%;
}

h2 {
    margin-left: 2%; 
    margin-top: 1%;
}

.image-container {
    display: flex;
    margin-left: 2%;
    margin-top: 3%;
    padding-left: 3%;
    padding-right: 2%;
}

.our-image>img {
    width: 75%;
    border-radius: 5%;
    border: 3px solid #611aa6;
}

.our-image {
    width: 25%;
}

#john-image {
    width: 24%;
}

#josh-image {
    margin-right: 0%;
}

.linkedin-container {
    display: flex;
    margin-left: 2%;
    padding-left: 3%;
    padding-right: 2%;
}

.linkedin-image img {
    width: 10%;
    margin-left: 30%;
    margin-top: 3%;
}
</style>
