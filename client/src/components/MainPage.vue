<template>
    <div id="app">
        <link href="https://fonts.googleapis.com/css?family=Material+Icons" rel="stylesheet">
        <full-page :options="options" id="fullpage">
            <div class="section fp-section">
                <div class="slide"> 
                    <v-container grid-list-md text-xs-center>
                        <v-layout row wrap>
                            <v-flex  xs6>
                                <v-card color="secondary" flat>
                                    <img src="https://img.icons8.com/bubbles/100/000000/restaurant.png" height="150"/>
                                </v-card>
                            </v-flex>
                            <v-flex  xs6>
                                <v-card color="secondary" flat>
                                    <a href="#page2"> 
                                        <h1 class=" display-1 ma-2 text-xs-left " style="color:black" >To restaurant</h1>
                                    </a>
                                    <a href="#page1/1"> 
                                        <h1 class=" display-1 ma-2 text-xs-left " style="color:black">To my reservation</h1>
                                    </a>
                                </v-card>
                            </v-flex>
                        </v-layout>
                    </v-container>
                </div>
                <div class="slide">
                    <v-container grid-list-md text-xs-center>
                        <v-layout row wrap>
                            <h1 class=" display-1 ma-2 text-xs-left " style="color:black">Please insert your reservation code: </h1>
                            
                            <v-flex xs12 sm6 md4>
                                <v-text-field
                                    label="Code"
                                    placeholder="your code.."
                                    box></v-text-field>
                            </v-flex>

                            <v-btn outline fab :disabled="true" color="indigo">
                                <v-icon dark>chevron_right</v-icon>
                            </v-btn>    
                        </v-layout>
                    </v-container>
                </div>
                <div class="slide">
                    <Appointments/>
                </div>
            </div>
            <div class="section">
                <Home @loadAppointments="onLoadAppointments"/>
            </div>
            <div class="section">
               <Agenda :events="events" :tableId="pickedTableId"/>
            </div>
            <div class="section">
              <VueCardPayment :settings="{
                                            labels: {
                                                cardNumber: 'Card number',
                                                month: 'Month',
                                                year: 'Year',
                                                cardHolder: 'Cardholder name',
                                                button: 'pay'
                                            },
                                            placeholders: {
                                                cardNumber: '0000 0000 0000 0000',
                                                month: '00',
                                                year: '00',
                                                cardHolder: 'JOHN DOE',
                                                cvv: '000'
                                            },
                                        
                                            showBank: true,
                                            showPaymentSystem: true
                                        }"/>
            </div>
        </full-page>
    </div>
</template>

<script>

require('@/utils/style.css')
import Home from './Home'
import Agenda from './Agenda'
import Appointments from './Appointments'

  export default {
    components: {
          Home,
          Agenda,
          Appointments
    },
    name: 'MainPage',
    data () {
      return {
        img: require('@/assets/IMG_8262.jpg'),
        options: {
          afterLoad: this.afterLoad,
          scrollOverflow: true,
          scrollBar: false,
          menu: '#menu',
          navigation: true,
          controlArrows: true,
          anchors: ['page1', 'page2', 'page3','page4'],
          sectionsColor: []
        },
        events: [],
        pickedTableId: 0
      }
    },
    created: function() {

      var int1 = setInterval(function(){
          var currentHour = new Date().getHours();

          if(currentHour == 10){
              clearInterval(int1);
          }
          
          },900000) //check time on 15min

    },
    methods: {
        addSection: function() {
            var newSectionNumber = document.querySelectorAll('.fp-section').length + 1

            // creating the section div
            var section = document.createElement('div')
            section.className = 'section'
            section.innerHTML = `<h3>Section ${newSectionNumber}</h3>`

            // adding section
            document.querySelector('#fullpage').appendChild(section)

            // creating the section menu element
            var sectionMenuItem = document.createElement('li')
            sectionMenuItem.setAttribute('data-menuanchor', 'page' + newSectionNumber)
            sectionMenuItem.innerHTML = `<a href="#page${newSectionNumber}">Section${newSectionNumber}</a>`

            // adding anchor for the section
            this.options.anchors.push(`page${newSectionNumber}`)

            // we have to call `update` manually as DOM changes won't fire updates
            // requires the use of the attribute ref="fullpage" on the
            // component element, in this case, <full-page>
            // ideally, use an ID element for that element too
            this.$refs.fullpage.build()
        },

        removeSection: function(){
            var sections = document.querySelector('#fullpage').querySelectorAll('.fp-section')
            var lastSection = sections[sections.length - 1]

            // removing the last section
            lastSection.parentNode.removeChild(lastSection)

            // removing the last anchor
            this.options.anchors.pop()

            // removing the last item on the sections menu
            var sectionsMenuItems = document.querySelectorAll('#menu li')
            var lastItem = sectionsMenuItems[sectionsMenuItems.length - 1]
            lastItem.parentNode.removeChild(lastItem)
        },
        onLoadAppointments: function(appointments, targetTableId) {
            appointments.forEach(a => a.date = new Date(a.date))
            this.events = appointments;
            this.pickedTableId = targetTableId;
        }
    }
};
</script>

