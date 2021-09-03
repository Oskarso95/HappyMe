document.addEventListener("DOMContentLoaded", function () {
  let iconLeft = document.getElementById("iconLeft");
  let iconRight = document.getElementById("iconRight");

  if (iconLeft != undefined) {
    iconLeft.addEventListener("click", showColumn, false);
  }
  if (iconRight != undefined) {
    iconRight.addEventListener("click", showColumn, false);
  }
});

let showColumn = (e) => {
  let id = e.target.id;
  let targetColumn = id.split(/(?=[A-Z])/)[1].toLowerCase() + "-column";
  let column = document.getElementsByClassName(targetColumn);

  console.log(column);
  if (column.length > 0) {
    console.log(column[0]);
  }
};
