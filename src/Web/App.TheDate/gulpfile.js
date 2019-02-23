const { src, dest, parallel, task } = require('gulp');
const uglify    = require('gulp-uglify');
const concat    = require('gulp-concat');
const watch     = require('gulp-watch');
const minifyCSS = require('gulp-minify-css');
const del       = require('del');

const paths = {
    typescripts:        ['Scripts/**/*.js', 'scripts/**/*.map'],
    materialize_css:    ['node_modules/materialize-css/dist/css/materialize.css'],
    materialize_js:     ['node_modules/materialize-css/dist/js/materialize.js'],
    jquery:             ['node_modules/jquery/dist/jquery.js'],
    requirejs:          ['node_modules/requirejs/require.js'],
    custom_files: {
        css:    'wwwroot/src/css/**/*.css',
        js:     'wwwroot/src/js/**/*.js',
        images: 'wwwroot/src/images/**'
    }
};

const dests = {
    css:    'wwwroot/bundle/css/',
    js:     'wwwroot/bundle/js/',
    ts:     'wwwroot/bundle/scripts/',
    images: 'wwwroot/images/'
};

task('custom_js', function (done) {
    src(paths.custom_files.js, { sourcemaps: true })
        .pipe(dest(dests.js, { sourcemaps: true }));
    done();
});

task('custom_css', function (done) {
    src(paths.custom_files.css)
        .pipe(minifyCSS())
        .pipe(dest(dests.css));
    done();
});

task('custom_images', function (done) {
    src(paths.custom_files.images)
        .pipe(dest(dests.images));
    done();
});

task('materialize_css', function (done) {
    src(paths.materialize_css)
        .pipe(minifyCSS())
        .pipe(concat('materialize.css'))
        .pipe(dest(dests.css));
    done();
});

task('materialize_js', function (done) {
    src(paths.materialize_js)
        .pipe(uglify())
        .pipe(concat('materialize.js'))
        .pipe(dest(dests.js));
    done();
});

task('requirejs', function (done) {
    src(paths.jquery)
        .pipe(uglify())
        .pipe(concat('require.js'))
        .pipe(dest(dests.js));
    done();
});

task('jquery', function (done) {
    src(paths.jquery)
        .pipe(uglify())
        .pipe(concat('jquery.js'))
        .pipe(dest(dests.js));
    done();
});

task('type_scripts', function (done) {
    src(paths.typescripts)
        //.pipe(uglify())
        .pipe(dest(dests.ts));
    done();
});

task('watchts', function () {
    // Endless stream mode
    return watch(paths.typescripts, { ignoreInitial: false })
        .pipe(dest(dests.ts));
});

//TODO CLEAN IMAGES !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
task('clean', function (done) {
    del(dests.css);
    del(dests.js);
    del(dests.ts);
    done();
});

task('default',
    parallel(
        'clean',
        'jquery',
        'custom_css',
        'custom_js',
        'custom_images',
        'materialize_css',
        'materialize_js',
        'type_scripts',
    )
);

