$(function () {
    var localizer = abp.localization.getResource('ProductManager');
    var dataTable = $('#ProductsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[0, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(
                productManager.products.product.getList),
            columnDefs: [
                {
                    title: localizer('Name'),
                    data: "name"
                },
                {
                    title: localizer('CategoryName'),
                    data: "categoryName",
                    orderable: false
                },
                {
                    title: localizer('Price'),
                    data: "price"
                },
                {
                    title: localizer('StockState'),
                    data: "stockState",
                    render: function (data) {
                        return l('Enum:StockState:' + data);
                    }
                },
                {
                    title: localizer('CreationTime'),
                    data: "creationTime",
                    dataFormat: 'date'
                }
            ]
        })
    );
});