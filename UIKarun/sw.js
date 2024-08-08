const cacheName = 'cache-v841228';
const dynamicCache = 'dyn-823228';
const assets = [
    '/',
     '/pwa.js',
   // '/offline.html',
    '/index.html',
    'manifest.json',
    	'app/views/toadd.html?vx=10',
	'app/views/forms.html?vx=10',
	'app/views/camera.html?vx=10',
	'app/views/ldgadd.html?vx=10',
	'app/views/library.html?vx=10',
	'app/views/document.html?vx=10',
    'app/views/calendar.html?vx=10',
    'app/views/logAdd.html?vx=10',
    'app/views/vrAdd.html?vx=10',
    'app/views/asrAdd.html?vx=10',
	'app/views/drAdd.html?vx=10',
	  'app/views/ofpAdd.html?vx=10',
	  'app/views/signAdd.html?vx=10',
	  'app/views/jl.html?vx=10',
	 'app/views/profileview.html?vx=10',
	'app/views/certificate.html?vx=10',
	 
	'app/views/stat.html?vx=10',
	'app/views/rptflightssimple.html?vx=10',
	'app/views/mb.html?vx=10',
    'app/views/taf.html?vx=10',
    'app/views/metar.html?vx=10',
    'app/views/notam.html?vx=10',
     'app/views/flights.html?vx=10' ,
	'pdfjsmodule/pdfviewernew.html?vx=10',
	 'app/views/imageviewer.html?vx=10',
    'app/views/header.html?vx=10',
    'app/views/menu.html?vx=10',
    '/app/views/login.html?vx=10',
    '/app/views/home.html?vx=10',
    //'app/views/logAdd.html',
    'app/views/footer.html?vx=10',
    '/app/app.js?vx=10',
    '/app/db.js?vx=10',
	'/lib/pspdfkit/pspdfkit-lib/pspdfkit-2021.5.1.css',
    '/content/css/bootstrap.css',
    '/content/css/w3.css',
    '/content/css/ionicons.css',
    '/content/css/dx.common.css',
    '/content/css/dx.material.material-teal-dark.css',
    '/content/css/fontawsome2.css',
   
    '/content/css/loading-bar.css',
    '/content/css/social-buttons.css',
    '/content/css/persian-datepicker.min.css',
    '/content/css/main.css?vx=10',
    '/content/css/core-ui.css',
    '/content/css/dx-hack.css?vx=10',
    '/content/css/icons/dxiconsmaterial.woff2',
    '/content/css/fonts/Roboto-400.woff2',
    '/content/css/fonts/Roboto-300.woff2',
    '/content/css/fonts/Roboto-300.woff',
    '/content/css/fonts/Roboto-300.ttf',
    '/scripts/jquery-3.1.0.js',
	 '/scripts/html2canvas.min.js',

    '/scripts/jszip.min.js',
    '/scripts/angular-1.7.2.js',
    '/scripts/angularjs-sanitize.js',
    '/scripts/angular-route-1.7.2.js',
    '/scripts/angular-animate.js',
    '/scripts/angular-local-storage.min.js',
    '/scripts/loading-bar.min.js',
    '/scripts/linq.min.js',
    '/scripts/moment-with-locales.min.js',
    '/scripts/persian-date.min.js',
    '/scripts/persian-datepicker.min.js',
    '/scripts/dx.all.js',
    '/scripts/mobile-detect.min.js',
    '/scripts/custom-tooltip.js',
    '/scripts/config.js?vx=10',
    '/scripts/core.js?vx=10',
    '/scripts/kit.fontawsome.js',
    '/scripts/dexie.js',
    '/app/services/authInterceptorService.js?vx=10',
    '/app/services/authService.js?vx=10',
    '/app/services/activityService.js?vx=10',

    '/app/services/testService.js?vx=10',
    '/app/services/tokensManagerService.js?vx=10',
    '/app/services/generalService.js?vx=10',
    '/app/services/notificationService.js?vx=10',
    '/app/services/libraryService.js?vx=10',
    '/app/services/flightService.js?vx=10',
	 '/app/services/statService.js?vx=10',
	'/app/services/mbService.js?vx=10',
    '/app/controllers/indexController.js?vx=10',
    //'/app/controllers/appsController.js',
     '/app/controllers/footerController.js?vx=10',
     '/app/controllers/homeController.js?vx=10',
    '/app/controllers/loginController.js?vx=10',
	'/app/controllers/toadd.js?vx=10',
	'/app/controllers/forms.js?vx=10',
	'/app/controllers/camera.js?vx=10',
			'/app/controllers/ldgadd.js?vx=10',
			'/app/controllers/appDocumentController.js?vx=10',
		'/app/controllers/appLibraryController.js?vx=10',
	'/app/controllers/mbController.js?vx=10',
   // '/app/controllers/signupController.js',

   // '/app/controllers/filterController.js',



    //'/app/controllers/refreshController.js',
    //'/app/controllers/tokensManagerController.js',
    //'/app/controllers/associateController.js',

    //'/app/controllers/appLibraryController.js',
    //'/app/controllers/appLibraryItemController.js',

    //'/app/controllers/appCertificateController.js',
    //'/app/controllers/fdpsController.js',
    //'/app/controllers/fdpController.js',
    //'/app/controllers/appCourseController.js',

    //'/app/controllers/appMessageItemController.js',
    //'/app/controllers/appMessageController.js',

    //'/app/controllers/appDocumentItemController.js',
    //'/app/controllers/appDocumentController.js',
    //'/app/controllers/appDocumentOtherController.js',
    //'/app/controllers/flightController.js',
    //'/app/controllers/flightStatsController.js',
    //'/app/controllers/flightLogBookController.js',

    //'/app/controllers/flightNewController.js',

    //'/app/controllers/passwordChangeController.js',
    //'/app/controllers/register1Controller.js',
    //'/app/controllers/register0Controller.js',
    //'/app/controllers/profileController.js',
    '/app/controllers/logAdd.js?vx=10',
	 '/app/controllers/ofpAdd.js?vx=10',
	 '/app/controllers/signAdd.js?vx=10',
	'/app/controllers/jl.js?vx=10',
	'/app/controllers/profileview.js?vx=10',
	'/app/controllers/appCertificateController.js?vx=10',
	'/app/controllers/statController.js?vx=10',
		'/app/controllers/rptflightssimple.js?vx=10',
	//'/app/controllers/appDocumentController.js?vx=10',
	
	
   // '/app/controllers/vrAdd.js?vx=10',
    //'/app/controllers/asrAdd.js?vx=10',
    '/app/controllers/taf.js?vx=10',
    '/app/controllers/metar.js?vx=10',
    '/app/controllers/notam.js?vx=10',
    //'/app/controllers/reports.js',
    //'/app/controllers/docViewer.js',
 '/pdfjsmodule/pdfviewernew.js?vx=10',
	
    '/app/controllers/epLogBook.js?vx=10', 
	 '/app/controllers/imageviewer.js?vx=10',
    '/app/controllers/calendarController.js?vx=10', 
    

    //'/app/controllers/pdfViewer.js',
    //'/app/controllers/reportViewer.js',
    
    '/content/css/free-v4-font-face.min.css',
    '/content/css/free.min.css',
    '/content/css/free-v4-shims.min.css',
    '/content/css/css_roboto_300_400_500_700.css',
   // 'https://fonts.googleapis.com/earlyaccess/notokufiarabic.css',
    '/content/css/free-fa-solid-900.woff2',
    '/content/css/free-fa-regular-400.woff2',
    '/content/css/KFOlCnqEu92Fr1MmEU9fBBc4.woff2',
    '/content/css/KFOmCnqEu92Fr1Mu4mxK.woff2',
    '/content/css/KFOlCnqEu92Fr1MmWUlfBBc4.woff2',
    '/content/css/KFOlCnqEu92Fr1MmSU5fBBc4.woff2',

    '/content/webfonts/fa-solid-900.woff2',
    '/content/webfonts/fa-regular-400.woff2',
    '/content/webfonts/fa-solid-900.woff',
    '/content/webfonts/fa-regular-400.woff',
    '/content/webfonts/fa-solid-900.ttf',
    '/content/webfonts/fa-regular-400.ttf',
    
     
    '/images/icons/icon-72x72.png',
    '/images/icons/icon-96x96.png',
    '/images/icons/icon-128x128.png',
    '/images/icons/icon-144x144.png',
    '/images/icons/icon-152x152.png',
    '/images/icons/icon-192x192.png',
    '/images/icons/icon-384x384.png',
    '/images/icons/icon-512x512.png',
    '/content/images/logo-white.png',
 '/images/empty.png',

   
    
];
self.addEventListener('install', e => {
    self.skipWaiting();
    e.waitUntil(
        caches.open(cacheName).then(cache => {
            // console.log('cache assets');
            cache.addAll(assets);

        })
    );


});

//activate eve
self.addEventListener('activate', evt => {
    evt.waitUntil(
        caches.keys().then(keys => {
            return Promise.all(keys
                .filter(key => key !== cacheName)
                .map(key => caches.delete(key))
            )
        })
    );
});

/*self.addEventListener('activate', event => {
// Remove old caches
  event.waitUntil(
    (async () => {
      const keys = await caches.keys();
      return keys.map(async (cache) => {
        if(cache !== cacheName) {
          console.log('Service Worker: Removing old cache: '+cache);
          return await caches.delete(cache);
        }
      })
    })()
  )
})*/

//self.addEventListener('fetch', function (event) {
//    // either respond with the cached object or go ahead and fetch the actual url

//    event.respondWith(
//        caches.match(event.request).then(function (response) {
//            if (response) {

//                return response;
//            }

//            return fetch(event.request);
//        })
//    );
//});
function get_url_extension(url) {
    return url.split(/[#?]/)[0].split('.').pop().trim();
}

self.addEventListener('fetch', evt => {
    //console.log('fetch starting ' + evt.request.url);
    var ext = '';
    var url2 = null;
    //if (evt.request.url.toLowerCase().includes("?file=")) {
    //    url2 = evt.request.url.split('?file=')[1];
    //    ext = get_url_extension(url2);
    //}
    //else
        ext = get_url_extension(evt.request.url);
   // console.log('fetch ext ' + ext);
    if ((ext == 'png' || ext == 'pdf') && evt.request.url.toLowerCase().includes("upload/")) {
        //console.log('***********************  1007');
        evt.respondWith(
            fetch(evt.request).then(response => {
               // console.log(ext, evt.request.url + '   ' + response.status);
                //console.log('response', response);
                return caches.open(dynamicCache).then(cache => {
                    cache.put(evt.request.url, response.clone());
                    return response;
                });
            }).catch(
                function () {
                    //offline
                   // console.log('catch error');
                    var _furl = url2 ? url2 : evt.request; 
                    return caches.match(_furl).then(cacheRes => {
                        //console.log('catch req', _furl); console.log('catch req2', cacheRes);
                        if (cacheRes)
                            return cacheRes;
                        else
                            return caches.match("http://localhost:20005/images/empty.png").then(nodata => { return nodata; });
                    });
                }
            )

            //fetch(evt.request).then(response => {
            //    console.log('png', evt.request.url + '   ' + response.status);
            //    console.log('response', response);

            //    if (response.status == 200)
            //        return caches.open(dynamicCache).then(cache => {
            //            cache.put(evt.request.url, response.clone());
            //            return response;
            //        });
            //    else
            //        return caches.match(evt.request).then(cacheRes => {
            //            console.log('catch req', evt.request); console.log('catch req', cacheRes);
            //            if (cacheRes)
            //                return cacheRes;
            //            else
            //                return caches.match("http://localhost:20005/images/empty.png").then(nodata => { return nodata; });
            //        });

            //}).catch(_ => {
            //    console.log('catch error');
            //    return caches.match(evt.request).then(cacheRes => {
            //        console.log('catch req', evt.request); console.log('catch req', cacheRes);
            //        if (cacheRes)
            //            return cacheRes;
            //        else
            //            return caches.match("http://localhost:20005/images/empty.png").then(nodata => { return nodata; });
            //    });
            //})

            //// END RESPOND
        );

        /// end png
    }
    else {
        evt.respondWith(

            caches.match(evt.request).then(cacheRes => {

                if (cacheRes) {
                    return cacheRes;
                }
                else if (!evt.request.url.includes('api/')) {


                    return fetch(evt.request).then(fetchRes => {
                        return caches.open(dynamicCache).then(cache => {
                            cache.put(evt.request.url, fetchRes.clone());
                            return fetchRes;
                        })
                    });



                }
                else return fetch(evt.request);



            })



        );
    }


});

self.addEventListener('_fetch', evt => {
    var ext = get_url_extension(evt.request.url);
    if (ext == 'png' && evt.request.url.toLowerCase().includes("upload/")) {
        evt.respondWith(
            fetch(evt.request).then(response => {
                //console.log('png', evt.request.url + '   ' + response.status);
               // console.log('response', response);

                if (response.status == 200)
                    return caches.open(dynamicCache).then(cache => {
                        cache.put(evt.request.url, response.clone());
                        return response;
                    });
                else
                    return caches.match(evt.request).then(cacheRes => {
                       // console.log('catch req', evt.request); console.log('catch req', cacheRes);
                        if (cacheRes)
                            return cacheRes;
                        else
                            return caches.match("http://localhost:20005/images/empty.png").then(nodata => { return nodata; });
                    });

            }).catch(_ => {
                //console.log('catch error');
                return caches.match(evt.request).then(cacheRes => {
                   // console.log('catch req', evt.request); console.log('catch req', cacheRes);
                    if (cacheRes)
                        return cacheRes;
                    else
                        return caches.match("http://localhost:20005/images/empty.png").then(nodata => { return nodata; });
                });
            })

            //// END RESPOND
        );

        /// end png
    }
    else {
        evt.respondWith(

            caches.match(evt.request).then(cacheRes => {

                if (cacheRes) {
                    return cacheRes;
                }
                else if (!evt.request.url.includes('api/')) {


                    return fetch(evt.request).then(fetchRes => {
                        return caches.open(dynamicCache).then(cache => {
                            cache.put(evt.request.url, fetchRes.clone());
                            return fetchRes;
                        })
                    });



                }
                else return fetch(evt.request);



            })



        );
    }


});