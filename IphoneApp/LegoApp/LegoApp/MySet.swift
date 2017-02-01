//
//  Set.swift
//  LegoApp
//
//  Created by Helena Tamburić on 19/01/2017.
//  Copyright © 2017 Helena Tamburić. All rights reserved.
//

import Foundation

import Unbox

struct MySet {
    let Id: Int
    let Ime: String
    let GodinaProizvodnje : Int
    let DijeloviBroj: Int
    let Opis: String?
    let NazivTema : String
    let NazivNadTema : String?
    let Slike : String
    let UputeUrl : String
    
}

extension MySet: Unboxable {
    init(unboxer: Unboxer) throws {
        self.Id = try unboxer.unbox(key: "Id")
        self.Ime = try unboxer.unbox(key: "Name")
        self.GodinaProizvodnje = try unboxer.unbox(key: "ProductionYear")
        self.DijeloviBroj = try unboxer.unbox(key: "NumberOfParts")
        self.Slike = try unboxer.unbox(key: "PictureUrl")
        self.UputeUrl = try unboxer.unbox(key: "InstructionsUrl")
        self.Opis = try unboxer.unbox(key: "Description")
        self.NazivTema = try unboxer.unbox(keyPath:"Theme.Name")
        self.NazivNadTema = try unboxer.unbox(keyPath:"BaseTheme.Name")
    }
}
