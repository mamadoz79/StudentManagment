function sltOrgUnits_selectedIndexChanged(sender, args) {    
    let grid = $find("grdSpecs");
    var tempEntity = grid.get_tempEntity();
    if (tempEntity != null) {
        Sys.Observer.setValue(tempEntity, "OrganizaionUnitName", sender.get_selectedText());
    }
}

function sltOrgUnits_itemRequesting(sender, args) {
    let grid = $find("grdSpecs");
    let list = grid.get_dataSourceObject().get_entityList();
    let editIndex = grid.get_editIndex();
    let ids = [];
    
    for (let i = 0; i < list.length; i++) {
        if (i != editIndex) {
            ids.push(list[i].OrganizationUnitRef);
        }
    }
    args.get_context()["IgnoredIDs"] = ids;
}
