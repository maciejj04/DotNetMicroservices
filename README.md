

    Projekt składa się z 3 mikroserwisów:
    - MicroserviceTemplateService(BusinessService) - apliacja analogiczna do poprzedniego projektu tj. CRQS. Udostępnia możliwość stworzenia wzorca dla aplikacji o architurze miktoserwisów, określić jej nazwe, opis, stack technologiczny itd.

    - ProxyService - z założenia serwis służący jako gateway/sidecar-proxy dla głównego serwisu biznesowego. Zewnętrzny użytkownik do niego wysyła swoje zapytania. Jego zadaniem jest dodanie do zapytania HTTP nagłówku "TraceId" za pomocą którego można korelować transakcje w systemie. Oprócz dodawnia naglówka wysyła on informacje o nadejściu zapytania/odpowiedzi z/do danego serwisu do "MonitoringService".
    
    - MonitoringService - odpowiada za odbieranie informacji od ProxyService o wchodzących do systemu transakcjach oraz za agregowanie ich po nagłówku "TraceId". Udostępnia możliwość sprawdzenia np. ile trwała transakcja od wejścia do systemu lub serwisu do jej wyjścia. 


    Przykładowy request do ProxyService:
    HTTP GET http://localhost:5001/api/microservice/
    Response:
    [
        {
            "id":0,"name":"queues-service",
            "description":"technica queues",
            "nativeLanguage":"Java8",
            "techStack":{"SpringBoot":"2.0","JRebel":"0.14"}
        }
    ]

    Następnie możemy sprawdzić wszystkie transakcje poprzez zapytanie do MonitoringService:
    HTTP GET http://localhost:5002/api/monitor/
    Response:
{
    "634503992": {
        "transactions": {
            "REQUEST": {
                "dateTime": "2017-12-10T20:35:51.5053869+01:00",
                "targetPath": "/api/microservice/",
                "type": 0
            },
            "RESPONSE": {
                "dateTime": "2017-12-10T20:35:51.9351911+01:00",
                "targetPath": "/api/microservice/",
                "type": 1
            }
        }
    }
}
widoczna powyżej liczba "634503992" to unikalna wartość nagłówka "TraceId" transakcji.
MonitoringService umożliwia również za pomocą zpytania GET sprawdzenia transakcji o danym TraceId:
HTTP GET http://localhost:5002/api/monitor/transactionInfo/634503992


Reszta funkcjonalność działa analogicznie do opisanych w poprzednim projekcie dotyczącym zagadnienia CQRS.

Do projektu zostały dodane pliki Dockerfile oraz docker-compose.yaml ale niestety nie zostały przetestowane ponieważ Docker nie dogaduje sie z Windowsem 10 Home. smutek.png