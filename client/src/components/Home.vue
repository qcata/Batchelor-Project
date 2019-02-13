<template>
    <div class="container-fluid">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

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
                dragSelector="div.card-header"
            >
                <div class="card demo-box" v-on:click="ceva()">
                </div>
            </dnd-grid-box>
        </dnd-grid-container>
    </div>
</template>
<style>
    .demo-box {
        width: 100%;
        height: 100%;
    }
</style>
<script> 


import { Container, Box } from '@dattn/dnd-grid'
import '@dattn/dnd-grid/dist/dnd-grid.css'

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
                layout: [
                    //sus
                    { id: 1, hidden: false, pinned: true, position: { x: 1, y: 1, w: 1, h: 2 } },
                    { id: 2, hidden: false, pinned: true, position: { x: 3, y: 1, w: 1, h: 2 } },
                    { id: 3, hidden: false, pinned: true, position: { x: 5, y: 1, w: 2, h: 2 } },
                    { id: 4, hidden: false, pinned: true, position: { x: 8, y: 1, w: 1, h: 2 } },
                    { id: 5, hidden: false, pinned: true, position: { x: 9, y: 1, w: 1, h: 2 } },
                    { id: 6, hidden: false, pinned: true, position: { x: 10, y: 1, w: 2, h: 2 } },
                    //mijloc intrare
                    { id: 7, hidden: false, pinned: true, position: { x: 1, y: 3, w: 1, h: 2 } },
                    { id: 8, hidden: false, pinned: true, position: { x: 1, y: 7, w: 1, h: 2 } },
                    //jos
                    { id: 9, hidden: false, pinned: true, position: { x: 1, y: 9, w: 1, h: 2 } },
                    { id: 10, hidden: false, pinned: true, position: { x: 9, y: 9, w: 1, h: 2 } },
                    { id: 11, hidden: false, pinned: true, position: { x: 10, y: 9, w: 1, h: 2 } },
                    { id: 12, hidden: false, pinned: true, position: { x: 11, y: 9, w: 1, h: 2 } },
                    { id: 13, hidden: false, pinned: true, position: { x: 3, y: 9, w: 2, h: 2 } },
                    { id: 14, hidden: false, pinned: true, position: { x: 5, y: 9, w: 1, h: 2 } },
                    { id: 15, hidden: false, pinned: true, position: { x: 6, y: 9, w: 2, h: 2 } },
                    //bar
                    { id: 16, hidden: false, pinned: true, position: { x: 4, y: 5, w: 5, h: 2 } },
                    //bar sus
                    { id: 17, hidden: false, pinned: true, position: { x: 4, y: 4, w: 0.5, h: 1 } },
                    { id: 18, hidden: false, pinned: true, position: { x: 4.5, y: 4, w: 0.5, h: 1 } },
                    { id: 19, hidden: false, pinned: true, position: { x: 5, y: 4, w: 0.5, h: 1 } },
                    { id: 20, hidden: false, pinned: true, position: { x: 5.5, y: 4, w: 0.5, h: 1 } },
                    { id: 21, hidden: false, pinned: true, position: { x: 6, y: 4, w: 0.5, h: 1 } },
                    { id: 22, hidden: false, pinned: true, position: { x: 6.5, y: 4, w: 0.5, h: 1 } },
                    { id: 23, hidden: false, pinned: true, position: { x: 7, y: 4, w: 0.5, h: 1 } },
                    { id: 24, hidden: false, pinned: true, position: { x: 7.5, y: 4, w: 0.5, h: 1 } },
                    { id: 25, hidden: false, pinned: true, position: { x: 8, y: 4, w: 0.5, h: 1 } },
                    { id: 26, hidden: false, pinned: true, position: { x: 8.5, y: 4, w: 0.5, h: 1 } },
                    //bar jos
                    { id: 27, hidden: false, pinned: true, position: { x: 4, y: 7, w: 0.5, h: 1 } },
                    { id: 28, hidden: false, pinned: true, position: { x: 4.5, y: 7, w: 0.5, h: 1 } },
                    { id: 29, hidden: false, pinned: true, position: { x: 5, y: 7, w: 0.5, h: 1 } },
                    { id: 30, hidden: false, pinned: true, position: { x: 5.5, y: 7, w: 0.5, h: 1 } },
                    { id: 31, hidden: false, pinned: true, position: { x: 6, y: 7, w: 0.5, h: 1 } },
                    { id: 32, hidden: false, pinned: true, position: { x: 6.5, y: 7, w: 0.5, h: 1 } },
                    { id: 33, hidden: false, pinned: true, position: { x: 7, y: 7, w: 0.5, h: 1 } },
                    { id: 34, hidden: false, pinned: true, position: { x: 7.5, y: 7, w: 0.5, h: 1 } },
                    { id: 35, hidden: false, pinned: true, position: { x: 8, y: 7, w: 0.5, h: 1 } },
                    { id: 36, hidden: false, pinned: true, position: { x: 8.5, y: 7, w: 0.5, h: 1 } },
                    //bar fata
                    { id: 37, hidden: false, pinned: true, position: { x: 3.5, y: 5, w: 0.5, h: 1 } },
                    { id: 38, hidden: false, pinned: true, position: { x: 3.5, y: 6, w: 0.5, h: 1 } },
                    //bar spate
                    { id: 39, hidden: false, pinned: true, position: { x: 9, y: 5, w: 0.5, h: 1 } },
                    { id: 40, hidden: false, pinned: true, position: { x: 9, y: 6, w: 0.5, h: 1 } },
                    //masa mare spate
                    { id: 41, hidden: false, pinned: true, position: { x: 11, y: 4, w: 1, h: 4 } },
                    
                ]
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
            ceva(){
              
            }
        }

        }


</script>

