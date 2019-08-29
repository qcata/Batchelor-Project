<template>

    <div class="container-fluid">
        
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
        <div class="boxContainer">
            <dnd-grid-container
                :layout.sync="layout"
                :cellSize="cellSize"
                :maxColumnCount="maxColumnCount"
                :maxRowCount="maxRowCount"
                :margin="margin"
                :bubbleUp="bubbleUp"
            >
                <dnd-grid-box
                    v-for="number in boxCount"
                    :boxId="number"
                    :key="number"
                    dragSelector="div.demo-box"
                >
                <!-- v-on:click="ceva(number)" -->
                    <div class="card demo-box" style="background-color:#C9E29E;" @click.stop="moveToPage(3,number)" @mouseover="ceva(number,true)" @mouseout="ceva(number,false)" :ref=number>
                    </div>
                </dnd-grid-box>
            </dnd-grid-container>
        </div>
    </div>

    
</template>
<style>
    .demo-box {
        width: 100%;
        height: 100%;
    }
    .boxContainer{
        display: flex;
        justify-content: center;
        padding-right: 5%;
    }
</style>
<script> 


import { Container, Box } from '@dattn/dnd-grid';
import '@dattn/dnd-grid/dist/dnd-grid.css';


    export default {
      components: {
            DndGridContainer: Container,
            DndGridBox: Box
        },
        name : 'Home',
        data () {
            return {
                cellSize: {
                    w: 100,
                    h: 50
                },
                maxColumnCount: 10,
                maxRowCount: Infinity,
                bubbleUp: false,
                margin: 10,
                boxCount: 41,
                tableItems: [
                    { title: '10:30' },
                    { title: '11:00' },
                    { title: '17:00' },
                    { title: '17:30' }
                ],
                layout: []
            }
        },
        computed: {
            layoutWithoutSettings () {
                return this.layout.filter((box) => {
                    return box.id !== 'settings'
                })
            }
        },
        methods: {
            onLayoutUpdate (evt) {
                this.layout = evt.layout
            },
            ceva(e,b){
              if(b == true)
                this.$refs[e][0].style.backgroundColor = "#FD626A";
              else
                this.$refs[e][0].style.backgroundColor = "#C9E29E";
            },
            moveToPage(pageNr,targetTable){
                location.hash = "#page" + pageNr;

                this.axios
                    .get('https://localhost:44379/Appointments/GetAppointments',
                    {
                        headers: {
                            'Access-Control-Allow-Origin': '*'
                        },
                        params: {
                            restaurantId: 1,
                            tableId: targetTable}
                    })
                    .then(response => {
                        this.$emit('loadAppointments', response.data, targetTable);
                    })
                    .catch(function() {
                    });
            }
        },
        mounted () {
          this.axios
            .get('https://localhost:44379/Tables/GetTables',{params: {restaurantId: 1}})
            .then(response => this.layout = response.data)
            .catch(function() {
              // console.log('ERROR::', error.data);
            });
        }

        }


</script>

