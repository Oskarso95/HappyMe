document.addEventListener("DOMContentLoaded", function () {
  let iconLeft = document.getElementById("icon-left");
  let iconRight = document.getElementById("icon-right");

  if (iconLeft != undefined) {
    iconLeft.addEventListener("click", showColumn, false);
  }
  if (iconRight != undefined) {
    iconRight.addEventListener("click", showColumn, false);
  }
});

let showColumn = (e) => {
  let id = e.target.id;
  let targetColumn = id.split("-")[1].toLowerCase();
  let column = document.getElementsByClassName(targetColumn);

  if (column.length > 0) {
    toggleColumn(column[0]);
  }
};

let toggleColumn = (targetColumn) => {
  let leftColumn = document.getElementsByClassName("left")[0] ?? "";
  let rightColumn = document.getElementsByClassName("right")[0] ?? "";

  if (targetColumn.isEqualNode(leftColumn)) {
    if (
      targetColumn.classList.contains("d-none") &&
      !rightColumn.classList.contains("d-none")
    ) {
      targetColumn.classList.remove("d-none");
      rightColumn.classList.add("d-none");
    }
  }

  if (targetColumn.isEqualNode(rightColumn)) {
    if (
      targetColumn.classList.contains("d-none") &&
      !leftColumn.classList.contains("d-none")
    ) {
      targetColumn.classList.remove("d-none");
      leftColumn.classList.add("d-none");
    }
  }
};
