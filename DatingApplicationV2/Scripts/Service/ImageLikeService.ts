import * as request from 'request';
import { stringify } from 'querystring';
export class ImageLikeService{
    GetImageLikes(id:string):number{
        request.get(APIUri.uri+"ImageLike/GetImageLikes/"+id+"/", (response: number)=>{
            return response;
        });
        throw new Error("Response from GetImageLikes is not a number!");
    }
}