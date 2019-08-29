<template>
<v-content>
  <div>
    <v-layout white--text align-center column justify-center style="margin-top: 15em; 
                                                                    position: absolute;
                                                                    margin-left: auto;
                                                                    margin-right: auto;
                                                                    left: 0;
                                                                    right: 0;">
          <img src="https://townshipcanada.com/static/logo.svg" height="150"/>
          <h3 class=" display-3 ma-2 text-xs-center">Restaurant</h3>
        </v-layout>
  </div>
  <div style="position: relative;">
      <parallax :fixed="false" :sectionHeight="10">
        <img :src="img" alt="very cool bg">
      </parallax>
  </div>
  
      <div>
      </div>
      <div style="background-color: #fff; height: 100vh;">
    <Home/>
  </div>
</v-content>
</template>





<script>

import Parallax from 'vue-parallaxy'
import Home from './Home'

export default {
        components: {
          Parallax,
          Home
        },
        name : 'PageTemplate',
        data(){
          return{
            img: require('@/assets/IMG_8262.jpg')
          }
        }
    }

</script>
