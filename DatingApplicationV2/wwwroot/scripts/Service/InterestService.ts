import * as request from 'request';
export class InterestService{
    Get(id: string): any {
        return request.get()
    }
    Create(model: any) {
        throw new Error("Method not implemented.");
    }
    Update(model: any) {
        throw new Error("Method not implemented.");
    }
    Edit(model: any): void {
        throw new Error("Method not implemented.");
    }
    Delete(id: string): void {
        throw new Error("Method not implemented.");
    }
}

