import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

  constructor(private httpClient: HttpClient, @Inject("baseurl") private baseurl: String) { }

  private url(requestParameter: Partial<RequestParametres>): string {
    return `${requestParameter.baseurl ? requestParameter.baseurl : this.baseurl}/${requestParameter.controler}${requestParameter.action ? `/${requestParameter.action}` : ""}`;
  }

  get<T>(requestParameter: Partial<RequestParametres>, id?: String): Observable<T> {
    let url: string;

    if (requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint;
    else
      url = `${this.url(requestParameter)}${id ? `/${id}` : ""}${requestParameter.queryString ? `?${requestParameter.queryString}` : ""}`;
    return this.httpClient.get<T>(url, { headers: requestParameter.headers })




  }
  post<T>(requestParameter: Partial<RequestParametres>, body: Partial<T>): Observable<T> {
    let url: string;
    if (requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint;
    else
      console.log(requestParameter, "requestParameter");

    url = `${this.url(requestParameter)}${requestParameter.queryString ? `?${requestParameter.queryString}` : ""}`

    return this.httpClient.post<T>(url, body, { headers: requestParameter.headers });

  }
  put<T>(requestParameter: Partial<RequestParametres>, body: Partial<T>): Observable<T> {
    let url: string;
    if (requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint;
    else
      url = `${this.url(requestParameter)}${requestParameter.queryString ? `?${requestParameter.queryString}` : ""}`
    return this.httpClient.put<T>(url, body, { headers: requestParameter.headers });
  }
  delete<T>(requestParameter: Partial<RequestParametres>, id: string): Observable<T> {
    let url: string;
    if (requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint;
    else
      url = `${this.url(requestParameter)}/${id}${requestParameter.queryString ? `?${requestParameter.queryString}` : ""}`
    return this.httpClient.delete<T>(url, { headers: requestParameter.headers });
  }

}

export class RequestParametres {
  controler?: string;
  action?: string;
  queryString?: string;
  headers?: HttpHeaders;
  baseurl?: string; //isteğe baplı başka bir yere istek atmak gerektiğinde kullanılabilr
  fullEndPoint?: string;

}
