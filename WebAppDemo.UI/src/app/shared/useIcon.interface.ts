import { MatIconRegistry } from "@angular/material/icon";
import { DomSanitizer } from "@angular/platform-browser";
import { IconType } from "./iconType.enum";

export interface UseIcon {
    matIconRegistry: MatIconRegistry;
    domSanitizer: DomSanitizer;
    iconTypes: IconType[];
}