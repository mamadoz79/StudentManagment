function sltStudent_OnClientItemsRequesting(sender, args) {
    let grid = $find("mainContainer_grdStudents");
    let list = grid.get_dataSourceObject().get_entityList();
    let editIndex = grid.get_editIndex();
    let ids = [];

    for (let i = 0; i < list.length; i++) {
        if (i != editIndex) {
            ids.push(list[i].StudentRef);
        }
    }
    args.get_context()["IgnoredIDs"] = ids;
}

