const SortableLists = [
];

function NestableCreate(id) {
  var el = document.getElementById(id);
  if (el == null || el == undefined) {
    console.log(id + " element not found");
return;
  }
  var sortable = Sortable.create(el,
    {
      ghostClass: "rz-background-color-base-400",
      animation: 150,
    });
  console.log('nestable list initialized: ' + id);
//  $('#' + id).sortable({
//    animation: 150,
//    ghostClass: 'blue-background-class',
//    onSort: reportActivity
//  });
//  console.log('nestable list initialized: ' + id);
//  console.log();
//  var order = $('#' + id).sortable('toArray');
//console.log(order);
}

function NestableGetOutput() {
  return $('#' + id).data('output');

}
function reportActivity() {
  console.log('The sort order has changed');
};