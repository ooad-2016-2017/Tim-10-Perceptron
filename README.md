# Perceptron

![alt text](/neuron.png "Neuron")

## Članovi Tima:
* Vedad Fejzagic
* Amar Buric
* Elvir Crncevic

# Interaktivna Mapa Evenata

## Opis teme:

Aplikacija za obavještavanje mušterija o aktuelnim događajima u gradskim kafanama, restoranima, festivalima, konferencijama itd. i registracija na iste. Osnovna svrha sistema je promocija i akvizicija mušterija putem interkativnog i viralnog marketinga. Za korisnika, ova platforma pruža jednostavan uvid u lokalne aktivnosti koje ih interesuju, za vlasnike predstavlja inovativni način obavještavanja, a za marketinšku firmu sistem koji omogućava bolje poslovanje. 

# Procesi

## Registracija mušterije
Korisnik popunjava lične podatke nakon čega dobiva mogućnost korištenja aplikacije ili odabire opciju da poveže svoj akaunt sa nekom od postojećih društvenih mreža čime se preskače proces unošenja ličnih podataka. Navodi listu interesovanja na osnovu kojih će biti filtrirani event koji joj se prikazuju.  

## Praćenje/Prekidanje praćenja aktivnosti mušterija
Mušterija ima mogućnost da prati ostale mušterije putem aplikacije tako da vidi eventove na koje su ostale mušterije prijavljene i da dobija notifikacije kada se praćene mušterije prijave tj. odjave sa eventa. Također, moguće je i prekinuti praćenje.

## Registracija organizatora eventa
Korisnik popunjava podatke o svom objektu/firmi/organizaciji, tipu eventova koje organizuju i kontakt informacije. Također, organizator bira jedan od ponuđenih planova plaćanja. Organizator nakon toga dobiva login podatke.

## Informisanje o aktivnim dešavanjima
Mapa se populiše eventima na osnovu prijašnjih aktivnosti mušterije, njenih navedenih interesovanja, kao i aktivnosti osoba koje prati. 
Ako se mušterija želi detaljnije informisati o specifičnom eventu, klikom na beacon eventa na mapi prikazuje se stranica sa dodatnim 
informacijama(potpuniji opis eventa, link na profil vlasnika, link za najavu dolaska, itd). 

## Prijava na event / Poništavanje prijave za event
Mušterija se prijavljuje na event preko interfejsa za koji postoji beacon na mapi. Ako mušterija ima osobe koje prati na aplikaciji, na interfejsu vidi koje osobe idu na event. Također, ima mogućnost poništavanje prijave na taj event.

## Validacija dolaska 
Fizičko prisustvo na eventu se validira generisanjem QR code-a na korisnikovom uređaju koji potom biva skeniran drugim uređajom, povezanim sa vlasnikom, a koji šalje potvrdu dolaska mušterije na server. Nakon validacije, mušterija dobija pristup promotivnoj ponudi, reklamiranoj putem aplikacije.

## Prijava / Poništavanje eventa 
Organizator eventa se prijavljuje na svoj akaunt i kreira novi event. Navodi naziv, mjesto, vrijeme i detaljan opis eventa. Kreacija novog eventa podrazumijeva navođenje specifikatora na osnovu kojih se odlučuje kojim korisnicima će taj event biti prikazan na mapi. Specifikatori uključuju dobnu grupu mušterija kojima je namijenjena aplikacija, spol, kategorija eventa kao i listu tagova. Organizator šalje direktnu notifikaciju o nastalom eventu svim mušterijama koje su subscribe-ovane na organizatora. Organizator eventa može poništiti event tako da se briše sa mape i briše iz pretrage. 

## Subscribe-anje na obavijesti organizatora eventa
Mušterija će imati mogućnost da se subscribe-a na organizatora eventa tako da dobija push notifikacije kada taj organizator objavi event. Moguće se i unsubscribe-ovati na organizatora tako da se push notifikacije ne šalju.

## Proširivanje liste tagova
Pri kreaciji akounta, mušterija navodi listu tagova koji opisuju njegova interesovanja. Pri kreaciji novog eventa, organizator koristi tagove da taj event opiše kako bi dosegao korisnike koji su za isti zainteresovani. Imajući pristup listi tagova, administrator može da dodaje ili briše tagove za evente. Nakon izmjene, skup mogućih tagova koje vlasnik može dodijeliti eventu pri njegovo kreaciji se mijenja u skladu sa tom izmjenom.
Flagovanje eventa i vlasnika eventa
S ciljem validacije pojedinačnih evenata, mušterije imaju opciju flagovanja evenata uz napisano objašnjenje. Admin odlučuje da li je potrebno ukloniti flagovani event ili primjeniti potpuni ban za korisnika koji je flagovan.	

# Funkcionalnosti

* Mogućnost prijave na aplikaciju sa različitim ulogama
* CRUD mogućnost nad mušterijskom i organizatorskom ulogom
* Registracija eventa sa organizatorskom ulogom
* Slanje notifikacija mušterijama koje prate organizaciju 
* Ažuriranje/brisanje eventa kao organizator 
* Uvid u aktivne eventove na mapi kao mušterija 
* Flitriranje aktivnosti po tagovima 
* Praćenje aktivnosti drugih mušterija uvidom u njihove prijave za evente, 
* Praćenje organizatora 
* Flagovanje sumnjivih evanata 
* Registracija na event 
* Skener koji validira dolazak mušterije
* Uvid u interesovanje mušterija za event
* Uvid u najbliže evente putem GPS-a
* Administratorska validacija organizatora

# Akteri

1) Administrator: ovaj posao obavlja marketinška firma koja ima mogućnost pretrage ostalih aktera, ažuriranja skupa tag-ova koje organizator može koristiti za opis eventa. Također, dobija informacije o flagovanim eventima i donosi odluku da li ih je potrebno otkazati.
2) Vlasnik lokala/Organizator eventa: osoba koja želi promovisati event i koristi naš sistem razvijen za marketinšku agenciju kako bi pronašla svoje mušterije; dobija feedback o interesovanju korisnika za njegov event
3) Mušterija: vidi interaktivnu mapu, navodi tipove evenata koji ga zanimaju, dobija obavijesti o novim dešavanjima, prati aktivnosti ostalih mušterija, registruje se za evente i dobija eventualne popuste na osnovu svojih aktivnosti za evente.Također, flaguje evente koji nisu primjereni za aplikaciju 
4) Uređaj za skeniranje: skenira QR kod prilikom dolaska mušterije na event, te šalje odgovarajuću informaciju bazi.
