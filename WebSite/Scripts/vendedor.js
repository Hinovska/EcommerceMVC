function VendedorSystemModel() {
    var self = this;
    self.VendedorToAdd = ko.observable();
    self.ListCiudadData = new Array();
    self.ListCiudad = ko.observableArray();
    self.ListVendedor = ko.observableArray();
    self.Init = function fnInit() {
        self.ApiRest.ListDictionary();
        self.VendedorToAdd(new Vendedor(0, "", "", "", "", self.ListCiudadData));
    };
    self.LoadGrid = function fnLoadGrid(data) {
        if (data && typeof (data) == "object") {
            var ListVendedores = new Array();
            data.map((item) => {
                console.log(item);
                var itemAdd = new Vendedor(item.codigo, item.nombres, item.apellidos, item.numero_identificacion, item.codigo_ciudad, self.ListCiudadData);
                ListVendedores.push(itemAdd);
            });
            self.ListVendedor(ListVendedores);
            self.EnableSystem(true);
        }
    };
    self.LoadDrop = function fnLoadDrop(data) {
        if (data && typeof (data) == "object") {
            var ListCiudades = new Array();
            ListCiudades.push(new Ciudad(0, "Ciudad..."));
            data.map((item) => {
                console.log(item);
                ListCiudades.push(new Ciudad(item.codigo, item.descripcion));
                self.ListCiudadData.push(new Ciudad(item.codigo, item.descripcion));
            });
            self.ListCiudad(ListCiudades);
            self.ApiRest.List();
        }
    };
    self.ApiRest = {
        ListDictionary: () => {
            $.ajax({
                type: "GET",
                url: "/api/ciudad",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    self.LoadDrop(data);
                },
                failure: function (data) {
                    alert(data.responseText);
                },
                error: function (data) {
                    alert(data.responseText);
                }
            });
        },
        List: () => {
            $.ajax({
                type: "GET",
                url: "/api/vendedor",
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
                    url: "/api/vendedor/" + Number(item.codigo),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        console.log(data);
                        self.ListVendedor().filter((item) => { return item.codigo == data.codigo; }).map((key) => {
                            key.nombre(data.nombres);
                            key.apellido(data.apellidos);
                            key.numero_identificacion(data.numero_identificacion);
                            key.codigo_ciudad(data.codigo_ciudad);
                        });
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
            if (self.VendedorToAdd() && typeof (self.VendedorToAdd()) != "undefined"
                && typeof (self.VendedorToAdd().nombre()) == "string" && self.VendedorToAdd().nombre().length > 0
                && typeof (self.VendedorToAdd().apellido()) == "string" && self.VendedorToAdd().apellido().length > 0
                && typeof (self.VendedorToAdd().numero_identificacion()) != "undefined" && !isNaN(self.VendedorToAdd().numero_identificacion()) && Number(self.VendedorToAdd().numero_identificacion()) > 0
                && typeof (self.VendedorToAdd().codigo_ciudad()) != "undefined" && !isNaN(self.VendedorToAdd().codigo_ciudad()) && Number(self.VendedorToAdd().codigo_ciudad()) > 0) {
                objdata = {
                    "nombres": self.VendedorToAdd().nombre(),
                    "apellidos": self.VendedorToAdd().apellido(),
                    "numero_identificacion": self.VendedorToAdd().numero_identificacion(),
                    "codigo_ciudad": Number(self.VendedorToAdd().codigo_ciudad())
                };
                $.ajax({
                    type: "POST",
                    url: "/api/vendedor",
                    data: JSON.stringify(objdata),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        console.log(data);
                        self.VendedorToAdd().nombre("");
                        self.VendedorToAdd().apellido("");
                        self.VendedorToAdd().numero_identificacion("");
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
            if (item && typeof (item) == "object" && item.hasOwnProperty("codigo") && !isNaN(item.codigo) && Number(item.codigo) > 0
                && typeof (item.nombre()) == "string" && item.nombre().length > 0
                && typeof (item.apellido()) == "string" && item.apellido().length > 0
                && typeof (item.numero_identificacion()) != "undefined" && !isNaN(item.numero_identificacion()) && Number(item.numero_identificacion()) > 0
                && typeof (item.codigo_ciudad()) != "undefined" && !isNaN(item.codigo_ciudad()) && Number(item.codigo_ciudad()) > 0) {
                objdata = {
                    "codigo": item.codigo,
                    "nombres": item.nombre(),
                    "apellidos": item.apellido(),
                    "numero_identificacion": item.numero_identificacion(),
                    "codigo_ciudad": Number(item.codigo_ciudad())
                };
                $.ajax({
                    type: "PUT",
                    url: "/api/vendedor/" + Number(objdata.codigo),
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
                    url: "/api/vendedor/" + Number(item.codigo),
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
    SelfItem.Selected = ko.observable(false);
    SelfItem.EditMode = ko.observable(false);
    SelfItem.SetEditMode = function fnSetEditMode(ciudad) {
        if (typeof (ciudad) != "undefined") {
            ciudad.EditMode((ciudad.EditMode()) ? false : true);
        }
    };
}

function Vendedor(codigo, nombre, apellido, num_identificacion, codigo_ciudad, lstCiuddes) {
    var SelfItem = this;
    SelfItem.codigo = codigo;
    SelfItem.nombre = ko.observable(nombre);
    SelfItem.apellido = ko.observable(apellido);
    SelfItem.numero_identificacion = ko.observable(num_identificacion);
    SelfItem.codigo_ciudad = ko.observable(codigo_ciudad);
    SelfItem.name_ciudad = ko.observable("");
    SelfItem.ListCiudadEdit = ko.observableArray(lstCiuddes);
    lstCiuddes.filter((ciudad) => { return ciudad.codigo == codigo_ciudad; }).map((key) => {
        SelfItem.name_ciudad(key.descripcion());
    });
    SelfItem.EditMode = ko.observable(false);
    SelfItem.SetEditMode = function fnSetEditMode(vendedor) {
        if (typeof (vendedor) != "undefined") {
            vendedor.EditMode((vendedor.EditMode()) ? false : true);
        }
    };
}

window.InitializeViewModel = function fnInitializeViewModel() {
    ko.options.useOnlyNativeEvents = true;
    if (typeof (window.VendedorSystemManager) == "undefined") { window.VendedorSystemManager = new VendedorSystemModel(); };
    window.VendedorSystemManager.Init();
    if (!!ko.dataFor(document.getElementById("VendedorContent")) == false) { ko.applyBindings(window.VendedorSystemManager); }
}

$(document).ready(function () {
    window.InitializeViewModel();
});
