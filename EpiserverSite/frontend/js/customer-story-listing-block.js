document.addEventListener("DOMContentLoaded", function() {
    var storyImages = document.getElementsByClassName("story__header--image");
    var storyPagination = document.getElementsByClassName("inner-dot");

    Array.from(storyImages).forEach(el => {
        el.addEventListener("click",swapStory,false);
    });

    Array.from(storyPagination).forEach(el => {
        el.addEventListener("click", swapStory, false)
    });
      
});

let swapStory = (e) => {
    let id = e.target.id;
    let idNumber = id.split("-")[1];
    let storyActiveID = "story-"+idNumber;
    let imageActiveID = "image-"+idNumber;
    let dotActiveID = "dot-"+idNumber; 
    let stories = document.getElementsByClassName("story__body");
    let dots = document.getElementsByClassName("inner-dot");
    let images = document.getElementsByClassName("story__header--image");
    
    swapActiveClass(dots,dotActiveID);
    swapActiveClass(images,imageActiveID);

    Array.from(stories).forEach(el => {
        if(el.classList.contains("d-flex") && el.id != storyActiveID){ //remove currently active stories
            el.classList.remove("d-flex");
            el.classList.add("d-none");
        }
        if(el.id === storyActiveID){
            console.log("match")
            el.classList.remove("d-none");
            el.classList.add("d-flex");
        }
    });
}

let swapActiveClass = (classList,activeID) => {
    Array.from(classList).forEach(el => {
        if(el.classList.contains("active") && el.id !== activeID){
            el.classList.remove("active");
        }
        if(el.id === activeID){
            el.classList.add("active")
        }
    })
}