import { HttpClient, json } from 'aurelia-fetch-client';

export abstract class WebApiService {

  protected constructor(private httpClient: HttpClient) {
    
  }

  protected get<TResult>(endpoint: string): Promise<TResult> {
    return this.createRequest("GET", endpoint, null, false);
  }

  protected post<TResult>(endpoint: string, data: any): Promise<TResult> {
    return this.createRequest("POST", endpoint, data, true);
  }

  protected put<TResult>(endpoint: string, data: any): Promise<TResult> {
    return this.createRequest("PUT", endpoint, data, true);
  }

  private createRequest<TResult>(method: string, endpoint: string, data: any, isProtected: boolean): Promise<TResult> {
    let requestInit: RequestInit = {
      method: method
    };

    if (data !== null) {
      requestInit.body = json(data);
    }

    return this.httpClient.fetch(endpoint, requestInit).then(response => response.json());
  }
}
