document.addEventListener("DOMContentLoaded", function () {
  let collapseables = document.getElementsByClassName("collapseables");
  if (collapseables.length > 0 && collapseables != undefined) {
    Array.from(collapseables).forEach((c) => {
      c.addEventListener("click", showCollapseContent);
    });
  }
});

let showCollapseContent = (e) => {
  e.preventDefault();
  let topLevelTag = e.target.parentNode.parentNode;
  console.log(topLevelTag);
  let collapseContent = topLevelTag.getElementsByClassName(
    "collapseable-content"
  );

  if (collapseContent != undefined && collapseContent.length > 0) {
    if (collapseContent[0].classList.contains("d-none")) {
      collapseContent[0].classList.remove("d-none");
      collapseContent[0].classList.add("d-flex");
    } else if (collapseContent[0].classList.contains("d-flex")) {
      collapseContent[0].classList.add("d-none");
      collapseContent[0].classList.remove("d-flex");
    }
  }
};
