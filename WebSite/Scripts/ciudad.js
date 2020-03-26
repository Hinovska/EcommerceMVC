function CiudadSystemModel() {
    var self = this;
    self.CiudadToAdd = ko.observable();
    self.ListCiudad = ko.observableArray();
    self.Init = function fnInit() {
        self.ApiRest.List();
    };
    self.LoadGrid = function fnLoadGrid(data) {
        if (data && typeof (data) == "object") {
            var ListCiudades = new Array();
            data.map((item) => {
                console.log(item);
                ListCiudades.push(new Ciudad(item.codigo, item.descripcion));
            });
            self.ListCiudad(ListCiudades);
            self.EnableSystem(true);
        }
    };
    self.ApiRest = {
        List: () => {
            $.ajax({
                type: "GET",
                url: "/api/ciudad",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    self.LoadGrid(data);
                },
                failure: function (data) {
                    alert(data.responseText);
                },
                error: function (data) {
                    alert(data.responseText);
                }
            });
        },
        Get: (item) => {
            if (item && typeof (item) == "object" && item.hasOwnProperty("codigo") && !isNaN(item.codigo) && Number(item.codigo) > 0) {
                $.ajax({
                    type: "GET",
                    url: "/api/ciudad/" + Number(item.codigo),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        console.log(data);
                        self.ListCiudad().filter((item) => { return item.codigo == data.codigo; }).map((key) => { key.descripcion(data.descripcion); });
                    },
                    failure: function (data) {
                        alert(data.responseText);
                    },
                    error: function (data) {
                        alert(data.responseText);
                    }
                });
            }
        },
        Create: () => {
            if (self.CiudadToAdd() && typeof (self.CiudadToAdd()) != "undefined") {
                objdata = { "descripcion": self.CiudadToAdd() };
                $.ajax({
                    type: "POST",
                    url: "/api/ciudad",
                    data: JSON.stringify(objdata),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        console.log(data);
                        self.ApiRest.List();
                    },
                    failure: function (data) {
                        alert(data.responseText);
                    },
                    error: function (data) {
                        alert(data.responseText);
                    }
                });
            }
        },
        Update: (item) => {
            item.EditMode(false);
            if (item && typeof (item) == "object" && item.hasOwnProperty("codigo") && !isNaN(item.codigo) && Number(item.codigo) > 0) {
                objdata = { "codigo": item.codigo, "descripcion": item.descripcion() };
                $.ajax({
                    type: "PUT",
                    url: "/api/ciudad/" + Number(objdata.codigo),
                    data: JSON.stringify(objdata),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        console.log(data);
                        self.ApiRest.List();
                    },
                    failure: function (data) {
                        alert(data.responseText);
                    },
                    error: function (data) {
                        alert(data.responseText);
                    }
                });
            }
        },
        Delete: (item) => {
            if (item && typeof (item) == "object" && item.hasOwnProperty("codigo") && !isNaN(item.codigo) && Number(item.codigo) > 0) {
                $.ajax({
                    type: "DELETE",
                    url: "/api/ciudad/" + Number(item.codigo),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        console.log(data);
                        self.ApiRest.List();
                    },
                    failure: function (data) {
                        alert(data.responseText);
                    },
                    error: function (data) {
                        alert(data.responseText);
                    }
                });
            }
        }
    }
    self.EnableSystem = ko.observable(false);
}

function Ciudad(codigo, descripcion) {
    var SelfItem = this;
    SelfItem.codigo = codigo;
    SelfItem.descripcion = ko.observable(descripcion);
    SelfItem.EditMode = ko.observable(false);
    SelfItem.SetEditMode = function fnSetEditMode(ciudad) {
        if (typeof (ciudad) != "undefined") {
            ciudad.EditMode((ciudad.EditMode()) ? false : true);
        }
    };
}

window.InitializeViewModel = function fnInitializeViewModel() {
    ko.options.useOnlyNativeEvents = true;
    if (typeof (window.CiudadSystemManager) == "undefined") { window.CiudadSystemManager = new CiudadSystemModel(); };
    window.CiudadSystemManager.Init();
    if (!!ko.dataFor(document.getElementById("CiudadContent")) == false) { ko.applyBindings(window.CiudadSystemManager); }
}

$(document).ready(function () {
    window.InitializeViewModel();
});
