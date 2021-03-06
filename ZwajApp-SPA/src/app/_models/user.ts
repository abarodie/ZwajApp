import { Photo } from "./photo";

export interface User {
    id:number;
    username:string;
    knownAs:string;
    age:number;
    gender:string;
    created:Date;
    lastActive:Date;
    photoURL:string;
    city:string;
    country:string;
    intersts?:string;
    inroduction?:string;
    lookingFor?:string;
    photos?:Photo[];
}
