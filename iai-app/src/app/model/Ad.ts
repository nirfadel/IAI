import { AdType } from './enums';
import { Location } from './Location';
export class Ad {
    id!: number;
    title!: string;
    content!: string;
    adDate!: Date;
    adType!: AdType;
    location!: Location;
}