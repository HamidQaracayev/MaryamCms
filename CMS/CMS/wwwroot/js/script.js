"use strict"
const modal=document.querySelector(".modal")
const overlay=document.querySelector(".overlay")
const btnClose=document.querySelector(".btn--close-modal")
const btnOpen=document.querySelectorAll(".btn--show-modal")
const closeModal=()=>{
    modal.classList.add("hidden")
    overlay.classList.add("hidden")
}
const openModal=()=>{
    modal.classList.remove("hidden")
    overlay.classList.remove("hidden")
// console.log(test)
}
 btnClose.addEventListener("click",function(e){
    e.preventDefault()
    closeModal()
 })
 
 overlay.addEventListener("click",function(e){
    e.preventDefault()
    closeModal()

 })
 btnOpen.forEach((el)=>
   el.addEventListener("click",function(e){
        e.preventDefault()
        openModal()
 }))
 window.addEventListener("keydown",function(e){
    if(e.key==="Escape" && !modal.classList.contains("hidden")){
        closeModal()
    }
 })