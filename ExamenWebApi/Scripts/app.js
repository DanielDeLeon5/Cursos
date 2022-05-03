var ViewModel = function () {
    var self = this;
    self.cursos = ko.observableArray();
    self.error = ko.observable();

    var cursosUri = '/api/Cursoes/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllCursos() {
        ajaxHelper(cursosUri, 'GET').done(function (data) {
            self.cursos(data);
        });
    }

    self.detalleCurso = ko.observable();

    self.getCursoDetalle = function (item) {
        ajaxHelper(cursosUri + item.Id, 'GET').done(function (data) {
            self.detalle(data);
        });
    }

    self.catedraticos = ko.observableArray();
    var catedraticosURI = '/api/Catedraticoes/';

    function getAllCatedraticos() {
        ajaxHelper(catedraticosURI, 'GET').done(function (data) {
            self.catedraticos(data);
        });
    }

    self.nuevoCurso = {
        Catedratico: ko.observable(),
        Nombre: ko.observable(),
        Categoria: ko.observable(),
        Descripcion: ko.observable()
    }
    self.agregarCurso = function (formElement) {
        var curso = {
            CatedraticoId: self.nuevoCurso.Catedratico().Id,
            Nombre: self.nuevoCurso.Nombre(),
            Categoria: self.nuevoCurso.Categoria(),
            Descripcion: self.nuevoCurso.Descripcion()
        };
        ajaxHelper(cursosUri, 'POST', curso).done(function (item) {
            self.curso.push(item);
        });
    }

    self.alumnos = ko.observableArray();

    var alumnosUri = '/api/Alumnoes/';

    function getAllAlumnos() {
        ajaxHelper(alumnosUri, 'GET').done(function (data) {
            self.alumnos(data);
        });
    }

    self.detalleAlumno = ko.observable();

    self.getAlumnoDetalle = function (item) {
        ajaxHelper(alumnosUri + item.Id, 'GET').done(function (data) {
            self.detalleAlumno(data);
        });
    }

    self.nuevoAlumno = {
        Curso: ko.observable(),
        Nombre: ko.observable(),
        Apellido: ko.observable(),
        DPI: ko.observable(),
        Edad: ko.observable()
    }
    self.agregarAlumno = function (formElement) {
        var alumno = {
            CursoId: self.nuevoAlumno.Curso().Id,
            Nombre: self.nuevoAlumno.Nombre(),
            Apellido: self.nuevoAlumno.Apellido(),
            DPI: self.nuevoAlumno.DPI(),
            Edad: self.nuevoAlumno.Edad()
        };
        ajaxHelper(alumnosUri, 'POST', alumno).done(function (item) {
            self.alumno.push(item);
        });
    }
    // Fetch the initial data.
    getAllCursos();
    getAllCatedraticos();
    getAllAlumnos();
};

ko.applyBindings(new ViewModel());