/**
 Tüm hakları saklıdır. Aralık, 2016
 CodeCillop.com , İstanbul, Türkiye
 **/

var $ = jQuery,
	zemincik = $('<div>', {
		class: 'zemincik'
	}),
	tasiyici = $('<div>', {
		class: 'tasiyici'
	});

/** işlem aşamasında **/

var islemGosterge = $('<div>', {
	class: 'islemde',
	html: '<div class="tablo"><div class="hucre"><em>İşlem Sürüyor</em></div></div>'
});

islemGosterge.appendTo($('body')).hide();

function islemde(icerdemi, yapistir) {
	if (icerdemi) {
		islemGosterge.appendTo(yapistir)
	} else {
		islemGosterge.appendTo($('body'));
	}
	islemGosterge.fadeIn(100);
}

function islembitti() {
	islemGosterge.fadeOut(100, function () {
		islemGosterge.appendTo($('body'));
	})
}

/** işlem aşamasında sonu **/

function tmz(bu) {
	return bu.replace(/\./g, '-').replace(/\//g, '-').replace(/\:/g, '-').replace(/\?/g, '-').replace(/\&/g, '-').replace(/\=/g, '-').replace(/\#/g, '');
}

function iframeScroll(uskeklik) { //scrollbar efekti
	if ($(window).width() > 1024) {
		var hedefframe = $('.yuklemecervesi').contents().find('#popup-icerik-alan').first();
		if ($('.muhtesempoap').data('sarma') != 0) {
			//hedefframe.height(uskeklik);
			//hedefframe.perfectScrollbar();
		}
	}
}

function poapiKapa() {
	var kapattusu = $('.muhtesempoap.etkin a.kapatcik');
	kapattusu.trigger('click');
	$('body').removeClass('sabit');
}

function poapiKapat(neyi, olcu) {
	neyi.animate({
		top: olcu + 'px'
	}, 150, function () {
		neyi.removeClass('mutlak etkin').css('top', '');
		zemincik.fadeOut(150);
		$('body').removeClass('sabit');
	});
}

function poapiOrtala(iframey) {
	var poapne = $('.muhtesempoap.etkin'),
		etkinYukseklik = poapne.find('.sayfaG').first().outerHeight(),
		sayfaEtkinYukseklik = $(window).outerHeight(),
		kaymaDeger, iframevarmi = poapne.find('iframe').length;
	badi = $('body');

	if (poapne.length > 0) {
		badi.addClass('sabit')
	} else {
		badi.removeClass('sabit')
	}

	if (iframevarmi > 0) {
		var iframe = poapne.find('iframe');
		if (iframey != undefined) {
			poapne.addClass('yukseklikvar');
			iframe.css('height', iframey + 'px')
			iframe.load(function (e) {
				iframeScroll(iframey);
			});
		} else {
			poapne.removeClass('yukseklikvar');
			iframe.css('height', sayfaEtkinYukseklik - 80 + 'px');
			iframe.load(function (e) {
				iframeScroll(sayfaEtkinYukseklik - 80);
			});
		}
		etkinYukseklik = poapne.find('.sayfaG').first().outerHeight();
	}

	kaymaDeger = (sayfaEtkinYukseklik / 2) - (etkinYukseklik / 2);
	if (kaymaDeger < 0) {
		kaymaDeger = $(document.body).scrollTop()
	};
	poapne.stop().animate({
		top: kaymaDeger + 'px'
	}, 300, function () {
		if (etkinYukseklik >= sayfaEtkinYukseklik) {
			poapne.addClass('mutlak');
			badi.removeClass('sabit');
		} else {
			poapne.removeClass('mutlak');
			badi.addClass('sabit');
		}
	});
}

function muhtesemPoap() {

	var poaptik = $('a.popup').add($('.popuplink a')),
		sahifeY, badi = $('body');

	poaptik.each(function (i, e) {

		/** neleri poap yapcaz, sadece class'ı popup olan # ile linklenmiş <a>'ları. **/

		var hankisi = $(this).attr('href'),
			kapilacak, hankisikes = false,
			capalilink = false,
			sarmaVarmi = $(e).data('sarma') == 0; /* REV2.1.G */

		if (hankisi.indexOf('#') === -1) {
			kapilacak = '';
		} else {

			var hankisikes = hankisi.split('#')[0].length > 0;
			if (hankisikes) {
				kapilacak = '';
				capalilink = true;
			} else {
				kapilacak = $('' + hankisi + '');
			}
		}

		var zatenolmusmu = $('.muhtesempoap[bukim=' + tmz(hankisi) + ']').hasClass('kapildi');

		var formicindemi;
		if (capalilink == false && hankisi.indexOf('#') != -1) {
			formicindemi = kapilacak.parents('form').first();
		}

		if (!zatenolmusmu) { /* birden fazla aynı link verilirse patlamasın */
			var muhtesempoap = $('<div>', {
				class: 'muhtesempoap',
				bukim: tmz(hankisi)
			}),
				kapatcik = $('<a>', {
					class: 'kapatcik',
					html: '×',
					href: 'javascript:;'
				});
			muhtesempoap.addClass('kapildi');
			if (sarmaVarmi) {
				muhtesempoap.attr('data-sarma', 0);
			}
			if (hankisi.indexOf('#') > -1 && capalilink == false && formicindemi.length > 0) {
				muhtesempoap.appendTo(formicindemi)
			}
			else {
				muhtesempoap.appendTo(badi);
			}
			if (hankisi.indexOf('#') != -1 && capalilink == false) {
				kapilacak.appendTo(muhtesempoap);
			}
			muhtesempoap.wrapInner('<div class="sayfaG"></div>');
			kapatcik.appendTo(muhtesempoap.children('.sayfaG').first());
		}

		/** tıklandıktan sonra da hedefini çağırcaz **/
		var bu = $(e);
		var linki = bu.attr('href'),
			linkarindir = tmz(linki);
		var ifaremmi = bu.data('iframe') != undefined,
			iframeyukseklik = bu.data('iframe-yukseklik');

		bu.unbind('click.poap').on('click.poap', function (e) {
			poapiKapa();
			var temizlink = tmz(bu.attr('href')),
				hedefi = $('.muhtesempoap[bukim=' + temizlink + ']'),
				hedefSayfaG = hedefi.children('.sayfaG');
			kapative = hedefi.find('a.kapatcik'), ustKacak = $(window).height() + 50, otoGen = bu.data('inline') != undefined, maxgAyar = bu.data('maksgen'), ozelclass = bu.data('class');

			if (otoGen) {
				hedefi.addClass('ortala');
				hedefSayfaG.addClass('dib')
			} else {hedefi.removeClass('ortala');
				hedefSayfaG.removeClass('dib')}
			if (maxgAyar != undefined) {
				hedefSayfaG.css('maxWidth', maxgAyar + 'px')
			} else {hedefSayfaG.css('maxWidth','')}
			if (ozelclass != undefined) {
				hedefi.addClass(ozelclass)
			} else {hedefi.removeClass(ozelclass)}
			e.preventDefault();

			/** sayfa içinden içerik çağırırsa **/
			if (linki.indexOf('#') > -1 && linki.split('#')[0].length <= 0) {
				hedefi.addClass('etkin');
				zemincik.appendTo(document.body).fadeIn(150, function () {
					poapiOrtala();
				});
			}

			/** dış sayfadan içerik çağırır **/
			if (linki.indexOf('#') > -1 && linki.split('#')[0].length > 0 && !ifaremmi) {

				hedefi.children('.sayfaG').prepend(tasiyici);

				if (ifaremmi) {
					islemde(true, hedefi.children('.sayfaG'));
				} else {
					islemde();
				}

				tasiyici.load(linki.replace("#", " #"), function (response, status, xhr) {
					if (status == "error") {
						var msg = "<h2>Bir hata oluştu, lütfen tekrar deneyin.</h2> ";
						tasiyici.html(msg + '<p>' + xhr.status + " " + xhr.statusText + '</p>');
						hedefi.addClass('etkin');
						zemincik.appendTo(document.body).fadeIn(150, function () {
							poapiOrtala();
						});
						islembitti();
					}
					if (status == "success") {
						hedefi.addClass('etkin');
						zemincik.appendTo(document.body).fadeIn(150, function () {
							poapiOrtala();
						});

						var gorsellimi = tasiyici.find('img').last();
						if (gorsellimi.length > 0) {
							gorsellimi.load(function () {
								poapiOrtala();
								islembitti();
							});
						} else {
							poapiOrtala();
							islembitti();
						}
					}
				});
			}

			/** iframe istenirse **/

			if (ifaremmi) {
				if (hedefi.find('iframe').length == 0) {
					var cercevesi = $('<iframe>', {
						class: 'yuklemecervesi',
						src: linki,
						width: '100%',
						height: '450',
						frameborder: '0',
						load: function () {
							islembitti();
						}
					});
					hedefi.children('.sayfaG').prepend(cercevesi);
					hedefi.addClass('iframe');
				} else {
					hedefi.find('iframe').attr('src', linki);
				}
				hedefi.addClass('etkin');
				islemde(true, hedefi.children('.sayfaG'));
				zemincik.appendTo(document.body).fadeIn(150, function () {
					poapiOrtala(iframeyukseklik);
				});
			}

			if (bu.hasClass('digerinegec')) {
				bu.parents('.sayfaG').find('a.kapatcik').click();
				setTimeout(function () {
					zemincik.fadeIn(150);
				}, 251);
			}
			kapative.unbind('click.kapatbakim').on('click.kapatbakim', function (e) {
				e.stopPropagation();
				poapiKapat(hedefi, ustKacak);
			});
			zemincik.unbind('click.kapatbakim').on('click.kapatbakim', function (e) {
				e.stopPropagation();
				poapiKapat(hedefi, ustKacak);
			});

			//esc e basınca da gitsin
			$(window).keydown(function (e) {
				var code = e.keyCode ? e.keyCode : e.which;
				if (code == 27) {
					//e.preventDefault();
					poapiKapat(hedefi, ustKacak);
				}
			});

			$(window).resize(function (e) {
				if (ifaremmi) {
					poapiOrtala(iframeyukseklik);
				} else {
					poapiOrtala();
				}

			});
		});
	});

}

$(function () {
	muhtesemPoap();
});

$(window).load(function () {
	muhtesemPoap();
});