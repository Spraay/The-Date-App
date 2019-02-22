var gulp = require('gulp'),
    uglify = require('gulp-uglify'),
    concat = require('gulp-concat'),
    minifyCSS = require('gulp-minify-css'),
    del = require('del');

function loadMaterializeCss() {
    gulp.src([
        'node_modules/materialize-css/dist/css/materialize.css'
    ])
        .pipe(minifyCSS())
        .pipe(concat('materialize.css'))
        .pipe(gulp.dest('wwwroot/css'));
}

function loadMaterializeJs() {
    gulp.src([
        'node_modules/materialize-css/dist/js/materialize.js'
    ])
        .pipe(uglify())
        .pipe(concat('materialize.js'))
        .pipe(gulp.dest('wwwroot/js'));
}

function loadJquery() {
    gulp.src([
        'node_modules/jquery/dist/jquery.js'
    ])
        .pipe(uglify())
        .pipe(concat('jquery.js'))
        .pipe(gulp.dest('wwwroot/js'));
}


gulp.task('default', function (done) {
    console.log("Started default task");
    loadJquery();
    loadMaterializeCss();
    loadMaterializeJs();
    done();
});

