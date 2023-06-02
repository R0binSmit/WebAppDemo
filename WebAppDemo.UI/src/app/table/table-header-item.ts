export class TableHeaderItem {
    dataPropertieName: string = "";
    displayName: string = "";

    constructor (dataPropertieName: string, displayName: string) {
        this.dataPropertieName = dataPropertieName;
        this.displayName = displayName;
    }
}