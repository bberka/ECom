const SortableDic = {};

function NestableCreate(id, listDirection, group, animation, disabled, delay, invertSwap, removeCloneOnHide, swapThreshold, invertedSwapThreshold) {
  var el = document.getElementById(id);
  if (el == null || el == undefined) {
    console.log(id + " element not found");
    return;
  }
  var sortable = Sortable.create(el,
    {
      ghostClass: "rz-background-color-base-400",
      animation: animation,
      dataIdAttr: 'data-id',
      direction: listDirection,
      group: group,
      delay: delay,
      disabled: disabled,
      invertSwap: invertSwap,
      removeCloneOnHide: removeCloneOnHide,
      swapThreshold: swapThreshold,
      invertedSwapThreshold: invertedSwapThreshold,
      onSort: function (event) {
        DotNet.invokeMethodAsync('on_sort', createObjectFromEvent(event));

      }
      //store: {
      //  get: function (sortable) {
      //    var order = localStorage.getItem('sortable-' + id);
      //    return order ? order.split('|') : [];
      //  },
      //  set: function (sortable) {
      //    var order = sortable.toArray();
      //    localStorage.setItem('sortable-' + id, order.join('|'));
      //  }
      //}


    });
  SortableDic[id] = sortable;

  console.log('nestable list initialized: ' + id);

}

function NestableGetOutput() {
  return $('#' + id).data('output');

}
function reportActivity() {
  console.log('The sort order has changed');
};
function NestableGetOrder(id) {
  var element = SortableDic[id];
  if (element == null || element == undefined) {
    return [];
  }
  var orderedList = element.toArray();
  return orderedList;
}

function createObjectFromEvent(event) {
  var obj = {
    oldIndex: event.oldIndex,
    newIndex: event.newIndex,
    oldDraggableIndex: event.oldDraggableIndex,
    newDraggableIndex: event.newDraggableIndex,
    willAddAfter: event.willAddAfter,
    pullMode: event.pullMode,
  }
  if (event.to) obj.toElementId = event.to.id;
  if (event.from) obj.fromElementId = event.from.id;
  if (event.dragged) obj.draggedElementId = event.dragged.id;
  if (event.related) obj.relatedElementId = event.related.id;
  return obj;
}